namespace CustomerFlow.BuildingBlocks.Messaging.IntegrationEvents;

public interface IIntegrationEvent
{
    Guid EventId => Guid.NewGuid();
    public DateTime OccurredOn => DateTime.Now;
    public string EventType => GetType().Name;
    public string ToKebabCase =>
        string.Concat(
            EventType.Select((x, i) =>
                char.IsUpper(x) && i > 0 ? "-" + char.ToLower(x) : char.ToLower(x).ToString()
            )
        );
}
