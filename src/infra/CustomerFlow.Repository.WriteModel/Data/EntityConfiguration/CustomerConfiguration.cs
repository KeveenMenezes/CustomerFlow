namespace CustomerFlow.Infra.CommandRepository.Data.EntityConfiguration;

public class CustomerConfiguration
    : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasOne(e => e.PayFrequency)
            .WithOne(s => s.Customer)
            .HasForeignKey<Customer>(m => m.PayFrequencyId);
    }
}
