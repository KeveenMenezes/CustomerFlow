namespace CustomerFlow.Core.Domain.AggregatesModel.CustomerAggregate.ValueObjects;

public partial class PhoneNumber(string value)
    : ValueObject<string>(Validate(value))
{
    private static string Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Phone number is required.", nameof(value));

        if (!MyRegex().IsMatch(value))
            throw new ArgumentException("Phone number must contain digits only.", nameof(value));

        return value;
    }

    public override string ToString() => Value;
    [GeneratedRegex(@"^\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{4}$")]
    private static partial Regex MyRegex();
}
