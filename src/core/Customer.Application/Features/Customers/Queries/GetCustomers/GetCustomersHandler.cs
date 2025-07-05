namespace CustomerFlow.Core.Application.Features.Customers.Queries.GetCustomers;

public class GetCustomersHandler(
    IQueryRepository queryRepository
) : IQueryHandler<GetCustomersQuery, GetCustomersResult>
{
    public async ValueTask<GetCustomersResult> Handle(
        GetCustomersQuery request, CancellationToken cancellationToken)
    {
        await using var connection = queryRepository.CreateConnectionAsync(cancellationToken);

        var getCustomers = await connection.QueryAsync<GetCustomerResult>(
            GetCustomersQuery.Query, cancellationToken);

        return new GetCustomersResult(getCustomers);
    }
}
