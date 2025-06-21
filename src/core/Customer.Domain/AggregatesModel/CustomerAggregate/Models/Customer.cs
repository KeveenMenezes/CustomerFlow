namespace CustomerFlow.Core.Domain.AggregatesModel.CustomerAggregate.Models;

public class Customer
    : Aggregate<int>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Email Email { get; private set; }
    public bool Active { get; private set; }
    public string? EmailVerificationCode { get; } // TODO: Implement email verification code generation logic
    public Password Password { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public string Address { get; private set; }
    public string City { get; private set; }
    public State State { get; private set; }
    public string ZipCode { get; private set; }
    public string Country { get; private set; }

    public static Customer Create(
        string firstName,
        string lastName,
        Email email,
        Password password,
        PhoneNumber phoneNumber,
        string address,
        string city,
        State state,
        string zipCode,
        string country)
    {
        var customer = new Customer
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password,
            PhoneNumber = phoneNumber,
            Address = address,
            City = city,
            State = state,
            ZipCode = zipCode,
            Country = country,
        };

        customer.AddDomainEvent(new CustomerCreatedEvent(customer));

        return customer;
    }

    public void VerifyEmailAccount(string verificationCode)
    {
        if (Active)
        {
            throw new InvalidOperationException("Email already verified.");
        }

        if (EmailVerificationCode != verificationCode)
        {
            throw new InvalidOperationException("Invalid verification code.");
        }

        Active = true;
        AddDomainEvent(new CustomerActivedEvent(Id, Email.Value));
    }

    public void UpdadePassword(Password newPassword)
    {
        if (newPassword.Value == Password.Value)
        {
            throw new InvalidOperationException("New password must be different from the current password.");
        }

        Password = newPassword;
        AddDomainEvent(new CustomerPasswordUpdatedEvent(Email.Value));
    }
}

