namespace CustomerFlow.BuildingBlocks.Core.DomainModel;

public interface IAggregate<TId>
    : IAggregate, IEntity<TId>
    where TId : IEntityId;

public interface IAggregate
    : IEntity
{
    IReadOnlyList<IDomainEvent> DomainEvents { get; }
    IDomainEvent[] ClearDomainEvents();
}
