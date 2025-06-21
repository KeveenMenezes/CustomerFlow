namespace CustomerFlow.Core.Domain.AggregatesModel.CustomerAggregate.ValueObjects;

public class Email(string value)
    : ValueObject<string>(Validate(value))
{
    private static string Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Email is required.", nameof(value));

        var emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        if (!Regex.IsMatch(value, emailRegex))
            throw new ArgumentException("Invalid email format.", nameof(value));

        return value;
    }

    public override string ToString() => Value;
}
