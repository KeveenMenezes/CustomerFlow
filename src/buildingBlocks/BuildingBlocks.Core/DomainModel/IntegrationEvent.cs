namespace CustomerFlow.BuildingBlocks.Core.DomainModel;

public record IntegrationEvent
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateTime OccurredOn { get; private set; } = DateTime.Now;
    public string EventType => GetType().Name;
    public string ToKebabCase =>
        string.Concat(
            EventType.Select((x, i) =>
                char.IsUpper(x) && i > 0 ? "-" + char.ToLower(x) : char.ToLower(x).ToString()
            )
        );
}
