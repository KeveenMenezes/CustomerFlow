namespace CustomerFlow.Core.Domain.AggregatesModel.CustomerAggregate.Models;

public class Customer
    : Aggregate<CustomerId>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Email Email { get; private set; }
    public bool Active { get; private set; }
    public string? EmailVerificationCode { get; }
    public Password Password { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public string Address { get; private set; }
    public string City { get; private set; }
    public State State { get; private set; }
    public string ZipCode { get; private set; }
    public string Country { get; private set; }

    public int? PayFrequencyId { get; private set; } = default!;
    public PayFrequency? PayFrequency { get; private set; }

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

        //customer.AddDomainEvent(new CustomerActivedEvent(customer));

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
    }

    public void UpdadePassword(Password newPassword)
    {
        if (newPassword.Value == Password.Value)
        {
            throw new InvalidOperationException("New password must be different from the current password.");
        }

        Password = newPassword;
        AddDomainEvent(new CustomerPasswordUpdatedEvent(this));
    }

    public void AddPayFrequency(
        int calendarId,
        string description,
        string frequency,
        int periodsPerYear,
        int payrollDiscountsPerYear,
        int sizeFlux,
        int countSizeFlux,
        int sumSizeFlux)
    {
        if (PayFrequency != null)
        {
            throw new InvalidOperationException("Pay frequency already exists for this customer.");
        }

        var payFrequency = PayFrequency.Create(
            Id,
            calendarId,
            description,
            frequency,
            periodsPerYear,
            payrollDiscountsPerYear,
            sizeFlux,
            countSizeFlux,
            sumSizeFlux);

        PayFrequency = payFrequency;

        //AddDomainEvent(new CustomerPayFrequencyAddedEvent(this));
    }
}
