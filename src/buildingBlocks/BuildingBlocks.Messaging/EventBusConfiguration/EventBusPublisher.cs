using CustomerFlow.BuildingBlocks.Messaging.IntegrationEvents;
using DotNetCore.CAP;

namespace CustomerFlow.BuildingBlocks.Messaging.EventBusConfiguration;

public class EventBusPublisher(
    ICapPublisher _capPublisher
) : IEventBusPublisher
{
    public async Task PublishAsync<T>(T value, CancellationToken cancellationToken = default)
        where T : IntegrationEvent
    {
        await _capPublisher.PublishAsync(
            value.ToKebabCase,
            value,
            callbackName: null,
            cancellationToken);
    }
}
