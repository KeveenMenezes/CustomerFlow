namespace CustomerFlow.Core.Domain.AggregatesModel.CustomerAggregate.Models;

public class PayFrequency : Entity<int>
{
    public int CalendarId { get; set; }
    public string Description { get; set; }
    public string Frequency { get; set; }
    public int PeriodsPerYear { get; set; }
    public int PayrollDiscountsPerYear { get; set; }
    public int SizeFlux { get; set; }
    public int CountSizeFlux { get; set; }
    public int SumSizeFlux { get; set; }

    private PayFrequency() { }

    public static PayFrequency Create(
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
