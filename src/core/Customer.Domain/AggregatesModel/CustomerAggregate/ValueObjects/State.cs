namespace CustomerFlow.Core.Domain.AggregatesModel.CustomerAggregate.ValueObjects;

public class State(string value)
    : ValueObject<string>(Validate(value))
{
    private static string Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("State is required.", nameof(value));

        if (value.Length != 2)
            throw new ArgumentException("State must be exactly 2 characters long.", nameof(value));

        return value.ToUpperInvariant();
    }

    public override string ToString() => Value;
}
