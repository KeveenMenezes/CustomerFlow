namespace CustomerFlow.Core.Domain.AggregatesModel.CustomerAggregate.ValueObjects.EntityIds;

public record PayFrequencyId : IEntityId
{
    private PayFrequencyId(int value) => Value = value;
    public int Value { get; }

    public static PayFrequencyId Of(int value)
    {
        if (value == default)
        {
            throw new ArgumentException("Value cannot be an empty int.", nameof(value));
        }
        return new PayFrequencyId(value);
    }
}
