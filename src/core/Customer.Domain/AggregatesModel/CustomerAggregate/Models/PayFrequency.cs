namespace CustomerFlow.Core.Domain.AggregatesModel.CustomerAggregate.Models;

public class PayFrequency : Entity<int>
{
    public string Description { get; private set; }
    public string Frequency { get; private set; }
    public int PeriodsPerYear { get; private set; }
    public int PayrollDiscountsPerYear { get; private set; }
    public int SizeFlux { get; private set; }
    public int CountSizeFlux { get; private set; }
    public int SumSizeFlux { get; private set; }

    public int CalendarId { get; private set; }

    public static PayFrequency Create(
        Id customerId,
        int calendarId,
        string description,
        string frequency,
        int periodsPerYear,
        int payrollDiscountsPerYear,
        int sizeFlux,
        int countSizeFlux,
        int sumSizeFlux) =>
        new()
        {
            CalendarId = calendarId,
            Description = description,
            Frequency = frequency,
            PeriodsPerYear = periodsPerYear,
            PayrollDiscountsPerYear = payrollDiscountsPerYear,
            SizeFlux = sizeFlux,
            CountSizeFlux = countSizeFlux,
            SumSizeFlux = sumSizeFlux
        };

    public bool IsEntityWithMoreThanOneFlux()
    {
        if (CountSizeFlux <= 1)
            return false;

        return (SizeFlux * CountSizeFlux) != SumSizeFlux;
    }
}
