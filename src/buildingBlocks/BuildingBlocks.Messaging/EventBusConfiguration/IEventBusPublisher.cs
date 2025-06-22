using CustomerFlow.BuildingBlocks.Messaging.IntegrationEvents;

namespace CustomerFlow.BuildingBlocks.Messaging.EventBusConfiguration;

public interface IEventBusPublisher
{
    Task PublishAsync<T>(T value, CancellationToken cancellationToken = default)
        where T : IntegrationEvent;
}
