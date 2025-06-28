namespace CustomerFlow.Core.Domain.AggregatesModel.CustomerAggregate.ValueObjects.EntityIds;

public record CustomerId : IEntityId
{
    private CustomerId(int value) => Value = value;
    public int Value { get; }

    public static CustomerId Of(int value)
    {
        if (value == default)
        {
            throw new ArgumentException("Value cannot be an empty int.", nameof(value));
        }
        return new CustomerId(value);
    }
}
