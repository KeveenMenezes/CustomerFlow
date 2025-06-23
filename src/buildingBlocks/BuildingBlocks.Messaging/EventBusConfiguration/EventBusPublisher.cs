using CustomerFlow.BuildingBlocks.Core.DomainModel;
using CustomerFlow.Core.Domain.Abstractions;
using DotNetCore.CAP;

namespace CustomerFlow.BuildingBlocks.Messaging.EventBusConfiguration;

public class EventBusPublisher(
    ICapPublisher _capPublisher
) : IEventBusPublisher
{
    private readonly List<IntegrationEvent> _integrationEvents = [];
    public IReadOnlyList<IntegrationEvent> IntegrationEvents => _integrationEvents.AsReadOnly();

    public void AddIntegrationEvent(IntegrationEvent integrationEvents)
    {
        _integrationEvents.Add(integrationEvents);
    }


    public IntegrationEvent[] ClearIntegrationEvents()
    {
        IntegrationEvent[] dequeuedEvents = [.. _integrationEvents];

        _integrationEvents.Clear();

        return dequeuedEvents;
    }

    public async Task PublishAsync(IntegrationEvent value, CancellationToken cancellationToken = default)
    {
        await _capPublisher.PublishAsync(
            value.ToKebabCase,
            value,
            callbackName: null,
            cancellationToken);
    }
}
