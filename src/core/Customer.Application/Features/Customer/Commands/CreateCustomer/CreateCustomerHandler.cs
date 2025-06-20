namespace CustomerFlow.Core.Application.Features.Customer.Commands.CreateCustomer;

public class CreateCustomerHandler
    : MediatorRequestHandler<CreateCustomerCommand, CreateCustomerResult>
{
    protected override Task<CreateCustomerResult> Handle(
        CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new CreateCustomerResult(1));
    }
}
