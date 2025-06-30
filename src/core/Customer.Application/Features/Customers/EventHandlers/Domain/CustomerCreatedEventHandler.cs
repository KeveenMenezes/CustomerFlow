using Mediator;

namespace CustomerFlow.Core.Application.Features.Customers.EventHandlers.Domain;

public class CustomerCreatedEventHandler(
    ICustomerIntegrationAdapter customerIntegrationAdapter,
    ICustomerCommandRepository customerCommandRepository,
    IEventBusPublisher publisher,
    ILogger<CustomerActivedEventHandler> logger)
    : INotificationHandler<CustomerCreatedEvent>
{
    public async ValueTask Handle(CustomerCreatedEvent domain, CancellationToken cancellationToken)
    {
        Console.WriteLine(domain.ToString());

        logger.LogInformation(domain.ToString());

        var (IsWebBank, StatesMessage) = await customerIntegrationAdapter.
            GetStateInfoAsync(domain.Aggregate.State.Value);

        var dataReplace = new Dictionary<string, string>
        {
            {"First Name", domain.Aggregate.FirstName},
            { "DISCLAIMER_TODAY_DATE", DateTime.Now.ToString("MM/dd/yyyy")},
            { "states_bmg", StatesMessage }
        };

        domain.Aggregate.UpdadePassword(new Password("NewPassword123"));

        await customerCommandRepository.UpdateAsync(domain.Aggregate, cancellationToken);

        publisher.AddIntegrationEvent(
            new SendVerificationTokenTwilio(
                dataReplace,
                SendTypeCommunication.Sms.ToValue(),
                IsWebBank ? "WebBank" : "Bank",
                null,
                domain.Aggregate.Id.Value,
                null,
                null));
    }
}
