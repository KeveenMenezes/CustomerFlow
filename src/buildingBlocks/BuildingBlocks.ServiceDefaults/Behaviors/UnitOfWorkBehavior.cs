using CustomerFlow.Core.Domain.Abstractions;

namespace CustomerFlow.BuildingBlocks.ServiceDefaults.Behaviors;

public class UnitOfWorkBehavior<TRequest, TResponse>(
    IEventBusPublisher eventBusPublisher,
    IUnitOfWork unitOfWork
)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, IRequest<TResponse>
    where TResponse : notnull
{
    public async ValueTask<TResponse> Handle(TRequest message, MessageHandlerDelegate<TRequest, TResponse> next, CancellationToken cancellationToken)
    {
        if (!IsCommand())
        {
            return await next(message, cancellationToken);
        }

        var response = await next(message, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        await DispatchIntegrationEvents(cancellationToken);

        return response;
    }

    private async Task DispatchIntegrationEvents(
        CancellationToken cancellationToken = default)
    {
        foreach (var integrationEvent in eventBusPublisher.ClearIntegrationEvents())
        {
            await eventBusPublisher.PublishAsync(integrationEvent, cancellationToken);
        }
    }

    private static bool IsCommand()
    {
        return typeof(TRequest).Name.EndsWith("Command", StringComparison.OrdinalIgnoreCase);
    }
}
