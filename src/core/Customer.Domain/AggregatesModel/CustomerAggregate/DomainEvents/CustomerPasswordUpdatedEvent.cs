namespace CustomerFlow.Core.Domain.AggregatesModel.CustomerAggregate.DomainEvents;

public record CustomerPasswordUpdatedEvent(string Email) : IDomainEvent;
