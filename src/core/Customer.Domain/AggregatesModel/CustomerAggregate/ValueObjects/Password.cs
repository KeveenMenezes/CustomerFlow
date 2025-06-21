namespace CustomerFlow.Core.Domain.AggregatesModel.CustomerAggregate.ValueObjects;

public partial class Password(string value)
    : ValueObject<string>(Validate(value))
{
    private static string Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Password is required.", nameof(value));

        if (!MyRegex().IsMatch(value))
            throw new ArgumentException("Password must contain at least one number.", nameof(value));

        return value;
    }

    public override string ToString() => Value;
    [GeneratedRegex("[0-9]")]
    private static partial Regex MyRegex();
}
