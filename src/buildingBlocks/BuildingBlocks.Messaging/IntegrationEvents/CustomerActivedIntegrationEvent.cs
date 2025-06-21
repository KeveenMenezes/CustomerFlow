namespace CustomerFlow.BuildingBlocks.Messaging.IntegrationEvents;

public record CustomerActivedIntegrationEvent(int CustomerId, string Email) : IntegrationEvent;
