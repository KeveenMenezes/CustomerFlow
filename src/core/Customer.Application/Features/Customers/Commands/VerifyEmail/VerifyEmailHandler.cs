namespace CustomerFlow.Core.Application.Features.Customers.Commands.VerifyEmail;

public class VerifyEmailHandler(
    ICustomerCommandRepository customerCommandRepository
) : ICommand<VerifyEmailCommand>
{
    public async ValueTask Handle(
        VerifyEmailCommand request, CancellationToken cancellationToken)
    {
        var customer = await customerCommandRepository.GetByIdAsync(
            request.CustomerId, cancellationToken) ??
            throw new NotFoundException(nameof(Customer), request);

        customer.VerifyEmailAccount(request.Code);

        await customerCommandRepository.SaveChangesAsync(cancellationToken);
    }
}
