
namespace CustomerFlow.Infra.CommandRepository.RepositoryAdapters;

public class CommandRepository<T>(
    CustomerFlowDbContext db,
    IUnitOfWork unitOfWork)
    : ICommandRepository<T> where T : class, IAggregate
{
    private readonly CustomerFlowDbContext _db = db;
    private DbSet<T> Entity => _db.Set<T>();

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await Entity.FindAsync([id], cancellationToken);
    }

    public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await Entity.FindAsync([id], cancellationToken);
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await Entity.AddAsync(entity, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        Entity.Update(entity);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        Entity.Remove(entity);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<T?> GetByIdAsync(Id id, CancellationToken cancellationToken = default)
    {
        return await Entity.FindAsync([id], cancellationToken);
    }
}
