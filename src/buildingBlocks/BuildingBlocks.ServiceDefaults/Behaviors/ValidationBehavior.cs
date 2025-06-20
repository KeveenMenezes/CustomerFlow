using CustomerFlow.BuildingBlocks.Core.CQRS;

namespace CustomerFlow.BuildingBlocks.ServiceDefaults.Behaviors;

public class ValidationBehavior<TRequest, TResponse>
    (IEnumerable<IValidator<TRequest>> validators)
    : IFilter<SendContext<TRequest>>
    where TRequest : class, ICommand<TResponse>
    where TResponse : class
{
    public void Probe(ProbeContext context)
    {
    }

    public async Task Send(SendContext<TRequest> context, IPipe<SendContext<TRequest>> next)
    {
        var validation = new ValidationContext<TRequest>(context.Message);

        var validationResults = await Task.WhenAll(
            validators.Select(v => v.ValidateAsync(validation)));

        var failures = validationResults
            .SelectMany(result => result.Errors)
            .Where(f => f != null)
            .ToList();

        if (failures.Count != 0)
        {
            throw new ValidationException(failures);
        }

        await next.Send(context);
    }
}
