namespace CustomerFlow.Core.Domain.AggregatesModel.CustomerAggregate.DomainEvents;

public record CustomerActivedEvent(int CustomerId, string Email) : IDomainEvent;
