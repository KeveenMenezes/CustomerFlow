namespace CustomerFlow.Core.Domain.AggregatesModel.CustomerAggregate.DomainEvents;

public record CustomerPasswordUpdatedEvent(Customer Aggregate)
    : IDomainEvent<Customer>;
