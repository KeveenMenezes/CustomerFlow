namespace CustomerFlow.Infra.CommandRepository.RepositoryAdapters;

public class UnitOfWork(CustomerFlowDbContext dbContext) : IUnitOfWork
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        await dbContext.SaveChangesAsync(cancellationToken);

    public void Dispose()
    {
        dbContext.Dispose();
    }

}
