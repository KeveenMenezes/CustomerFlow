using CustomerFlow.Core.Domain.Abstractions;
using CustomerFlow.Infra.CustomerIntegrationAdapter.Interfaces;

namespace CustomerFlow.Infra.CustomerIntegrationAdapter;

public class CustomerIntegrationAdapter(
    ICustomerIntegrationApi customerIntegrationApi)
    : ICustomerIntegrationAdapter
{
    public async Task<(bool IsWebBank, string StatesMessage)> GetStateInfoAsync(string customerStateAbbreviation)
    {
        return (true, string.Empty);
    }
}
