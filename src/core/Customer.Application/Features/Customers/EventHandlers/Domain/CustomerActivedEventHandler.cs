using Mediator;

namespace CustomerFlow.Core.Application.Features.Customers.EventHandlers.Domain;

public class CustomerActivedEventHandler(
    ICustomerIntegrationAdapter customerIntegrationAdapter,
    IEventBusPublisher publisher,
    ILogger<CustomerActivedEventHandler> logger)
    : INotificationHandler<CustomerActivedEvent>
{
    public async ValueTask Handle(CustomerActivedEvent domain, CancellationToken cancellationToken)
    {
        logger.LogInformation(domain.ToString());

        var (IsWebBank, StatesMessage) = await customerIntegrationAdapter.
            GetStateInfoAsync(domain.State);

        var dataReplace = new Dictionary<string, string>
        {
            {"First Name", domain.FirstName},
            { "DISCLAIMER_TODAY_DATE", DateTime.Now.ToString("MM/dd/yyyy")},
            { "states_bmg", StatesMessage }
        };

        publisher.AddIntegrationEvent(
            new SendVerificationTokenTwilio(
                dataReplace,
                SendTypeCommunication.Sms.ToValue(),
                IsWebBank ? "WebBank" : "Bank",
                null,
                domain.CustomerId,
                null,
                null));
    }
}
