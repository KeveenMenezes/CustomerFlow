namespace CustomerFlow.Core.Domain.AggregatesModel.CustomerAggregate.Abstractions;

public interface ICustomerCommandRepository
    : ICommandRepository<Customer>
{
    public Task UpadatePasswordAsync(
        Id customerId,
        string password,
        CancellationToken cancellationToken = default);
}
