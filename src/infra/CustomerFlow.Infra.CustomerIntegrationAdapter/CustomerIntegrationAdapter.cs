using CustomerFlow.Core.Domain.Abstractions;
using CustomerFlow.Infra.CustomerIntegrationAdapter.Dtos;
using CustomerFlow.Infra.CustomerIntegrationAdapter.Interfaces;

namespace CustomerFlow.Infra.CustomerIntegrationAdapter;

public class CustomerIntegrationAdapter(
    ICustomerIntegrationApi customerIntegrationApi)
    : ICustomerIntegrationAdapter
{
    public async Task<(bool IsWebBank, string StatesMessage)> GetStateInfoAsync(string customerStateAbbreviation)
    {
        var statesResponse = await customerIntegrationApi.GetStateReponse();

        if (!statesResponse.IsSuccessStatusCode)
            throw new InvalidOperationException("Failed to get state response from customer info client");

        var data = statesResponse.Content?.Data;

        bool isWebBank = data?.WebBankStates?.Any(x =>
            x.StateAbbreviation == customerStateAbbreviation) ?? false;

        return (isWebBank, BuildStatePhrase(data));
    }

    private static string BuildStatePhrase(StateResponseDTO? states)
    {
        if (states?.BmgMoneyStates == null || states.BmgMoneyStates.Count == 0)
            return string.Empty;

        var abbreviations = states.BmgMoneyStates
            .Where(x => x.StateAbbreviation != "WA")
            .Select(x => x.StateAbbreviation)
            .ToList();

        return abbreviations.Count switch
        {
            0 => string.Empty,
            1 => abbreviations[0],
            _ => string.Join(", ", abbreviations.Take(abbreviations.Count - 1)) + " and " + abbreviations[^1]
        };
    }
}
