namespace CustomerFlow.Core.Domain.AggregatesModel.CustomerAggregate.DomainEvents;

public record CustomerActivedEvent(
    Customer Customer
) : IDomainEvent;
