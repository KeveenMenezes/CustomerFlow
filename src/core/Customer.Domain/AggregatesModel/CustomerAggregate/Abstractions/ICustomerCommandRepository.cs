namespace CustomerFlow.Core.Domain.AggregatesModel.CustomerAggregate.Abstractions;

public interface ICustomerCommandRepository
    : ICommandRepository<Customer, Id, PublicId>
{
    public Task UpadatePasswordAsync(
        Id customerId,
        string password,
        CancellationToken cancellationToken = default);
}
