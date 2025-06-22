namespace CustomerFlow.Infra.CustomerIntegrationAdapter.Dtos;

public record VerificationCodeRequest(string RecipientNumber, string Token);
