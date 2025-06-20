namespace CustomerFlow.Core.Domain.AggregatesModel.CustomerAggregate.Models;

public class Customer
    : Aggregate<int>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Address { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }
    public string Country { get; private set; }

    public static Customer Create(
        string firstName,
        string lastName,
        string email,
        string phoneNumber,
        string address,
        string city,
        string state,
        string zipCode,
        string country)
    {
        var customer = new Customer
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            PhoneNumber = phoneNumber,
            Address = address,
            City = city,
            State = state,
            ZipCode = zipCode,
            Country = country
        };

        return customer;
    }
}

