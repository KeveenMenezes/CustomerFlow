namespace CustomerFlow.Core.Domain.AggregatesModel.CustomerAggregate.DomainEvents;

public record CustomerActivedEvent(
    int CustomerId,
    string FirstName,
    string State
) : IDomainEvent;
