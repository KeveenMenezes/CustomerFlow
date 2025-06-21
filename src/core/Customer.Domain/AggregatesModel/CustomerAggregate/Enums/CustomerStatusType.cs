namespace CustomerFlow.Core.Domain.AggregatesModel.CustomerAggregate.Enums;

public enum CustomerStatusType
{
    Current = 1,
    Settled = 2,
    BankruptcyPending = 3,
    BankruptcyDischarged = 4,
    BankruptcyDismissed = 5,
    Deceased = 6,
    Fraud = 7,
    ChargeOff = 8
}

public static class CustomerStatusTypeExtensions
{
    public static string GetName(this CustomerStatusType status)
    {
        return status switch
        {
            CustomerStatusType.Current => "Current",
            CustomerStatusType.Settled => "Settled",
            CustomerStatusType.BankruptcyPending => "Bankruptcy Pending",
            CustomerStatusType.BankruptcyDischarged => "Bankruptcy Discharged",
            CustomerStatusType.BankruptcyDismissed => "Bankruptcy Dismissed",
            CustomerStatusType.Deceased => "Deceased",
            CustomerStatusType.Fraud => "Fraud",
            CustomerStatusType.ChargeOff => "ChargeOff",
            _ => string.Empty,
        };
    }
}
