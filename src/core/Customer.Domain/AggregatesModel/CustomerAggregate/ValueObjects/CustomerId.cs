namespace CustomerFlow.Core.Domain.AggregatesModel.CustomerAggregate.ValueObjects;

public class Id
{
    public Id() { } // <-- Make this public
    public Id(int value)
    {
        Value = value;
    }
    public int Value { get; }
}

public class PublicId
{
    public PublicId() { } // <-- Make this public

    public PublicId(Guid value)
    {
        Value = value;
    }

    public PublicId Set(Guid value)
    {
        return new PublicId(value);
    }

    public Guid Value { get; }
}
