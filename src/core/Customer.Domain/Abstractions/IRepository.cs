using CustomerFlow.BuildingBlocks.Core.DomainModel;

namespace CustomerFlow.Core.Domain.Abstractions;

public interface IRepository<T> where T : IAggregate
{
    public Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    public Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    public Task AddAsync(T entity, CancellationToken cancellationToken = default);
    public Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    public Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
    public Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
