namespace CustomerFlow.BuildingBlocks.Messaging.IntegrationEvents;

public record SendVerificationTokenTwilio(
    Dictionary<string, string>? DataReplace,
    string SendType,
    string CommunicationType,
    DateTime? SendDate,
    long CustomerId,
    string? LoanNumber,
    string? Attachment
) : IntegrationEvent;
