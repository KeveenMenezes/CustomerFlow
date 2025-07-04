namespace CustomerFlow.Infra.CommandRepository.Data.EntityConfiguration;

public class PayFrequencyConfiguration
    : IEntityTypeConfiguration<PayFrequency>
{
    public void Configure(EntityTypeBuilder<PayFrequency> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(o => o.Id)
            .HasConversion(
                customerId => customerId.Value,
                dbId => PayFrequencyId.Of(dbId))
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Frequency)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.PeriodsPerYear).IsRequired();
        builder.Property(p => p.PayrollDiscountsPerYear).IsRequired();
        builder.Property(p => p.SizeFlux).IsRequired();
        builder.Property(p => p.CountSizeFlux).IsRequired();
        builder.Property(p => p.SumSizeFlux).IsRequired();
        builder.Property(p => p.CalendarId).IsRequired();

        builder.Property(p => p.CustomerId)
            .IsRequired();
    }
}
