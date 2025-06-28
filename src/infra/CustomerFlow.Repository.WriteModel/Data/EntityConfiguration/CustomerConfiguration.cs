namespace CustomerFlow.Infra.CommandRepository.Data.EntityConfiguration;

public class CustomerConfiguration
    : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
            .HasConversion(
                customerId => customerId.Value,
                dbId => CustomerId.Of(dbId))
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Email)
            .HasConversion(
                d => d.Value,
                s => new Email(s))
            .HasColumnName("email")
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder.Property(c => c.Password)
            .HasConversion(
                d => d.Value,
                s => new Password(s))
            .HasColumnName("password")
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder.Property(c => c.PhoneNumber)
            .HasConversion(
                d => d.Value,
                s => new PhoneNumber(s))
            .HasColumnName("phoneNumber")
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder.Property(c => c.State)
            .HasConversion(
                d => d.Value,
                s => new State(s))
            .HasColumnName("state")
            .HasColumnType("varchar(5)")
            .IsRequired();


        builder.HasOne(c => c.PayFrequency)
            .WithOne(pf => pf.Customer)
            .HasForeignKey<PayFrequency>(pf => pf.CustomerId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
