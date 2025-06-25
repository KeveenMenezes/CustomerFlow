namespace CustomerFlow.Infra.CommandRepository.RepositoryAdapters;

public class CommandRepository<T>(
    CustomerFlowDbContext db)
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
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        Entity.Update(entity);
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        Entity.Remove(entity);
    }
}

public class CommandRepository<T, TId, TPublicId>(
    CustomerFlowDbContext db)
    : CommandRepository<T>(db), ICommandRepository<T, TId, TPublicId>
    where T : class, IAggregate<TId, TPublicId>
{
    private readonly CustomerFlowDbContext _db = db;

    public async Task<T?> GetByPublicIdAsync(TPublicId publicId, CancellationToken cancellationToken = default)
    {
        return await _db.Set<T>().FirstOrDefaultAsync(
            e => EF.Property<TPublicId>(e, "PublicId")!.Equals(publicId),
            cancellationToken);
    }
}
