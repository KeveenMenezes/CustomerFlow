namespace BuildingBlocks.Core.DomainModel;

public interface IDomainEvent
{
    Guid EventId => Guid.NewGuid();
    public DateTime OccurredOn => DateTime.Now;
    public string EventType => GetType().AssemblyQualifiedName!;

    public string ToString()
    {
        return $"[DomainEvent] Type: {EventType} | OccurredOn: {OccurredOn:O} | EventId: {EventId}";
    }
}
