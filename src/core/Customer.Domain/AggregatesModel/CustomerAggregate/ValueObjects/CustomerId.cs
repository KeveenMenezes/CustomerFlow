namespace CustomerFlow.Core.Domain.AggregatesModel.CustomerAggregate.ValueObjects;

public class Id
{
    private Id(int value) => Value = value;

    public static Id Of(int value)
    {
        if (value == 0)
        {
            //TODO: criar uma exception customizada
            throw new ArgumentException($"Invalid customer id: {value}", nameof(value));
        }

        return new Id(value);
    }

    public int Value { get; }
}
