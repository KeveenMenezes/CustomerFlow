using CustomerFlow.Infra.CustomerIntegrationAdapter.Dtos;
using Refit;

namespace CustomerFlow.Infra.CustomerIntegrationAdapter.Interfaces;

public interface ICustomerIntegrationApi
{
    [Post("/validateCode")]
    Task<ApiResponse<VerificationCodeResult>> ValidateSmsCode(VerificationCodeRequest request);

    [Get("/web-bank")]
    Task<ApiResponse<StateResponse>> GetStateReponse();
}
