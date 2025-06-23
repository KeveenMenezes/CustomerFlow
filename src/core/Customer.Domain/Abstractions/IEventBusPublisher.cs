namespace CustomerFlow.Core.Domain.Abstractions;

public interface IEventBusPublisher
{
    IReadOnlyList<IntegrationEvent> IntegrationEvents { get; }
    IntegrationEvent[] ClearIntegrationEvents();

    Task PublishAsync(IntegrationEvent value, CancellationToken cancellationToken = default);
    void AddIntegrationEvent(IntegrationEvent integrationEvents);
}
