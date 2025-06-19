namespace BuildingBlocks.Core.DomainModel;

public class ValueObject<T>
    : IEquatable<ValueObject<T>>
    where T : IComparable<T>
{
    public T Value { get; }

    public ValueObject(T value)
    {
        Value = value;
    }

    public bool Equals(ValueObject<T>? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return EqualityComparer<T>.Default.Equals(Value, other.Value);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((ValueObject<T>)obj);
    }

    public override int GetHashCode()
    {
        return EqualityComparer<T>.Default.GetHashCode(Value);
    }

    public static bool operator ==(ValueObject<T>? left, ValueObject<T>? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(ValueObject<T>? left, ValueObject<T>? right)
    {
        return !Equals(left, right);
    }
}
