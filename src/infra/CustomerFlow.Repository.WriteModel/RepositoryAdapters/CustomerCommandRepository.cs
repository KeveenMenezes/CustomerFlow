namespace CustomerFlow.Infra.CommandRepository.RepositoryAdapters;

public class CustomerCommandRepository(CustomerFlowDbContext dbContext)
    : CommandRepository<Customer>(dbContext), ICustomerCommandRepository
{
}
