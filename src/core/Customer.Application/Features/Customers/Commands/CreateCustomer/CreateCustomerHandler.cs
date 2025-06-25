namespace CustomerFlow.Core.Application.Features.Customers.Commands.CreateCustomer;

public class CreateCustomerHandler(
    ICustomerCommandRepository customerCommandRepository
)
    : ICommandHandler<CreateCustomerCommand, CreateCustomerResult>
{
    public async ValueTask<CreateCustomerResult> Handle(
        CreateCustomerCommand request,
        CancellationToken cancellationToken)
    {
        var customer = Customer.Create(
            publicId: new PublicId(Guid.NewGuid()),
            firstName: request.FirstName,
            lastName: request.LastName,
            email: new Email(request.Email),
            password: new Password(request.Password),
            phoneNumber: new PhoneNumber(request.PhoneNumber),
            address: request.Address,
            city: request.City,
            state: new State(request.State),
            zipCode: request.ZipCode,
            country: request.Country
        );

        await customerCommandRepository.AddAsync(customer, cancellationToken);

        return new CreateCustomerResult(customer.Id);
    }
}
