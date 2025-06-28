namespace CustomerFlow.Core.Domain.AggregatesModel.CustomerAggregate.DomainEvents;

public record CustomerCreatedEvent(Customer Aggregate)
    : IDomainEvent<Customer>;

