namespace CustomerFlow.Infra.CommandRepository.Data;

public class CustomerFlowDbContext(DbContextOptions<CustomerFlowDbContext> options)
    : DbContext(options)
{
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<PayFrequency> PayFrequencies => Set<PayFrequency>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
