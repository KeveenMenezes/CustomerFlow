namespace CustomerFlow.Core.Domain.Abstractions;

public interface ICustomerIntegrationAdapter
{
    Task<(bool IsWebBank, string StatesMessage)> GetStateInfoAsync(string customerStateAbbreviation);
}
