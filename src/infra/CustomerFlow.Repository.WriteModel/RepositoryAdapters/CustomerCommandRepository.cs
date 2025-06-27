namespace CustomerFlow.Infra.CommandRepository.RepositoryAdapters;

public class CustomerCommandRepository(
    CustomerFlowDbContext dbContext)
    : CommandRepository<Customer>(dbContext), ICustomerCommandRepository
{
    private readonly CustomerFlowDbContext _dbContext = dbContext;

    public async Task UpadatePasswordAsync(
        Id customerId, string password, CancellationToken cancellationToken = default)
    {
        await _dbContext.Customers
            .Where(c => c.Id == customerId)
            .ExecuteUpdateAsync(
                u => u.SetProperty(c => c.Password, new Password(password)),
                cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
