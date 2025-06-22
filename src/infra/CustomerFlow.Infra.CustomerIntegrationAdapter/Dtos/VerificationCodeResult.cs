namespace CustomerFlow.Infra.CustomerIntegrationAdapter.Dtos;

public record VerificationCodeResult(
    string Sid,
    string To,
    string Status);
