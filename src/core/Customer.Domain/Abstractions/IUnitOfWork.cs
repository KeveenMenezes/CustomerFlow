namespace CustomerFlow.Core.Domain.Abstractions;

public interface IUnitOfWork : IDisposable
{
    Task ExecuteInTransactionAsync(Func<Task> operation, CancellationToken cancellationToken = default);
}
