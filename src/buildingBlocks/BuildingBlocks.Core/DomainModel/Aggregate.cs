namespace CustomerFlow.BuildingBlocks.Core.DomainModel;

public abstract class Aggregate<TId, TPublicId>
    : Entity<TId, TPublicId>, IAggregate<TId, TPublicId>
    where TId : new()
    where TPublicId : new()
{
    protected Aggregate() { }
    private readonly List<IDomainEvent> _domainEvents = [];
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public IDomainEvent[] ClearDomainEvents()
    {
        IDomainEvent[] dequeuedEvents = [.. _domainEvents];

        _domainEvents.Clear();

        return dequeuedEvents;
    }
}

public abstract class Aggregate<TId>
    : Entity<TId>, IAggregate<TId>
    where TId : new()
{
    protected Aggregate() { }
    private readonly List<IDomainEvent> _domainEvents = [];
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public IDomainEvent[] ClearDomainEvents()
    {
        IDomainEvent[] dequeuedEvents = [.. _domainEvents];

        _domainEvents.Clear();

        return dequeuedEvents;
    }
}
