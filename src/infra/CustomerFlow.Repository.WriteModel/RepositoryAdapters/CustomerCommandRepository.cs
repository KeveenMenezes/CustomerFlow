namespace CustomerFlow.Infra.CommandRepository.RepositoryAdapters;

public class CustomerCommandRepository(CustomerFlowDbContext dbContext)
    : CommandRepository<Customer, Id, PublicId>(dbContext), ICustomerCommandRepository
{
    public async Task UpadatePasswordAsync(
        Id customerId, string password, CancellationToken cancellationToken = default)
    {
        await dbContext.Customers
            .Where(c => c.Id == customerId)
            .ExecuteUpdateAsync(
                u => u.SetProperty(c => c.Password, new Password(password)),
                cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
