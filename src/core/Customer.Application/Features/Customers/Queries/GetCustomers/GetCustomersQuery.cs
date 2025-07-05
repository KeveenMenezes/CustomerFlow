namespace CustomerFlow.Core.Application.Features.Customers.Queries.GetCustomers;

public record GetCustomersQuery()
    : IQuery<GetCustomersResult>
{
    public const string Query = @"
        SELECT
            id,
            firstName,
            lastName,
            email,
            phoneNumber,
            address,
            city,
            state,
            zipCode,
            country
        FROM Customers";
}


public record GetCustomersResult(
    IEnumerable<GetCustomerResult> Customers
);


public record GetCustomerResult(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string Address,
    string City,
    string State,
    string ZipCode,
    string Country
);
