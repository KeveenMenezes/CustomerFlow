namespace CustomerFlow.Core.Domain.AggregatesModel.CustomerAggregate.Abstractions;

public interface ICustomerCommandRepository
    : ICommandRepository<Customer>
{
    public Task UpadatePasswordAsync(
        CustomerId customerId,
        string password,
        CancellationToken cancellationToken = default);
}
