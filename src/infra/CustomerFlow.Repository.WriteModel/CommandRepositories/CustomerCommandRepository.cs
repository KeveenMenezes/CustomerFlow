namespace CustomerFlow.Infra.CommandRepository.CommandRepositories;

public class CustomerCommandRepository(
    CustomerFlowDbContext dbContext)
    : CommandRepository<Customer>(dbContext), ICustomerCommandRepository
{
    private readonly CustomerFlowDbContext _dbContext = dbContext;

    public async Task UpadatePasswordAsync(
        CustomerId customerId, string password, CancellationToken cancellationToken = default)
    {
        await _dbContext.Customers
            .Where(c => c.Id == customerId)
            .ExecuteUpdateAsync(
                u => u.SetProperty(c => c.Password, new Password(password)),
                cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
