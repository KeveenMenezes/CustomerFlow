namespace CustomerFlow.BuildingBlocks.Messaging.IntegrationEvents;

public record IntegrationEvent
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateTime OccurredOn { get; private set; } = DateTime.Now;
    public string EventType => GetType().Name;
}
