namespace CustomerFlow.Core.Domain.AggregatesModel.CustomerAggregate.DomainEvents;

public record CustomerActivedEvent(Customer Aggregate)
    : IDomainEvent<Customer>;
