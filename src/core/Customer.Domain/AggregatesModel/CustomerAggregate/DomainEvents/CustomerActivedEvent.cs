namespace CustomerFlow.Core.Domain.AggregatesModel.CustomerAggregate.DomainEvents;

public record CustomerActivedEvent(
    PublicId PublicId,
    string FirstName,
    State State,
    Id Id
) : IDomainEvent;
