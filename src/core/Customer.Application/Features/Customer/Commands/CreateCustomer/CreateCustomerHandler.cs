namespace CustomerFlow.Core.Application.Features.Customer.Commands.CreateCustomer;

public class CreateCustomerHandler
    : ICommandHandler<CreateCustomerCommand, CreateCustomerResult>
{
    public async ValueTask<CreateCustomerResult> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        // Simulação de operação assíncrona
        await Task.Yield();
        return new CreateCustomerResult(1);
    }
}
