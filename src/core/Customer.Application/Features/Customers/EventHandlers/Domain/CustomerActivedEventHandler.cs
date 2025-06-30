using Mediator;

namespace CustomerFlow.Core.Application.Features.Customers.EventHandlers.Domain;

public class CustomerActivedEventHandler(
    ILogger<CustomerActivedEventHandler> logger)
    : INotificationHandler<CustomerActivedEvent>
{
    public async ValueTask Handle(CustomerActivedEvent domain, CancellationToken cancellationToken)
    {
        Console.WriteLine(domain.ToString());
    }
}
