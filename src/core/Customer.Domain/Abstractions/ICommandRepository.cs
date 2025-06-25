namespace CustomerFlow.Core.Domain.Abstractions;

public interface ICommandRepository<T>
    where T : IAggregate
{
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
}

public interface ICommandRepository<T, TId, TPublicId>
    : ICommandRepository<T>
    where T : IAggregate<TId, TPublicId>
{
    Task<T?> GetByPublicIdAsync(TPublicId publicId, CancellationToken cancellationToken = default);
}
