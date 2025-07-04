namespace CustomerFlow.Core.Application.Features.Customers.Commands.VerifyEmail;

public class VerifyEmailHandler(
    ICustomerCommandRepository customerCommandRepository
) : ICommandHandler<VerifyEmailCommand>
{
    public async ValueTask<Mediator.Unit> Handle(
        VerifyEmailCommand request, CancellationToken cancellationToken)
    {
        var customer = await customerCommandRepository.GetByIdAsync(
            request.CustomerId, cancellationToken) ??
            throw new NotFoundException(nameof(Customer), request);

        customer.VerifyEmailAccount(request.Code);

        await customerCommandRepository.UpdateAsync(customer, cancellationToken);

        return Mediator.Unit.Value;
    }
}
