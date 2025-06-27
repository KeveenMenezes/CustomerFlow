using CustomerFlow.BuildingBlocks.Core.DomainModel;
using CustomerFlow.Core.Domain.AggregatesModel.CustomerAggregate.ValueObjects;

namespace CustomerFlow.BuildingBlocks.Messaging.IntegrationEvents;

public record SendVerificationTokenTwilio(
    Dictionary<string, string>? DataReplace,
    string SendType,
    string CommunicationType,
    DateTime? SendDate,
    int CustomerId,
    string? LoanNumber,
    string? Attachment
) : IntegrationEvent;
