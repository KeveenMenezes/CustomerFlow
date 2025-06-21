namespace CustomerFlow.Infra.CommandRepository.Data;

public class CustomerFlowDbContext(DbContextOptions<CustomerFlowDbContext> options)
    : DbContext(options)
{

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
