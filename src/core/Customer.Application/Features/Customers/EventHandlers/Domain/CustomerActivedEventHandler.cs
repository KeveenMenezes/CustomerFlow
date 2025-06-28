using Mediator;

namespace CustomerFlow.Core.Application.Features.Customers.EventHandlers.Domain;

public class CustomerActivedEventHandler(
    ICustomerIntegrationAdapter customerIntegrationAdapter,
    ICustomerCommandRepository customerCommandRepository,
    IEventBusPublisher publisher,
    ILogger<CustomerActivedEventHandler> logger)
    : INotificationHandler<CustomerActivedEvent>
{
    public async ValueTask Handle(CustomerActivedEvent domain, CancellationToken cancellationToken)
    {
        logger.LogInformation(domain.ToString());

        var (IsWebBank, StatesMessage) = await customerIntegrationAdapter.
            GetStateInfoAsync(domain.Aggregate.State.Value);

        var dataReplace = new Dictionary<string, string>
        {
            {"First Name", domain.Aggregate.FirstName},
            { "DISCLAIMER_TODAY_DATE", DateTime.Now.ToString("MM/dd/yyyy")},
            { "states_bmg", StatesMessage }
        };

        var test = await customerCommandRepository.GetByIdAsync(domain.Aggregate.Id, cancellationToken);

        test.UpdadePassword(new Password("NewPassword123"));

        await customerCommandRepository.UpdateAsync(test, cancellationToken);

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
