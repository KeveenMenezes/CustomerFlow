using Mediator;

namespace CustomerFlow.Core.Application.Features.Customers.EventHandlers.Domain;

public class CustomerActivedEventHandler(
    IPublisher publisher,
    ILogger<CustomerActivedEventHandler> logger)
    : INotificationHandler<CustomerActivedEvent>
{
    public async ValueTask Handle(CustomerActivedEvent domain, CancellationToken cancellationToken)
    {
        logger.LogInformation(domain.ToString());

        await publisher.Publish(
            new CustomerActivedIntegrationEvent(domain.CustomerId, domain.Email),
            cancellationToken);
    }
}
