using CustomerFlow.BuildingBlocks.ServiceDefaults.QueriesAbstractions;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace CustomerFlow.Infra.QueryRepository.Repositories;

public class QueryRepository(
    IServiceProvider serviceProvider,
    IConfiguration configuration
) : IQueryRepository
{
    public MySqlConnection CreateConnectionAsync(CancellationToken cancellationToken)
    {

        ArgumentNullException.ThrowIfNull(serviceProvider, nameof(serviceProvider));
        ArgumentNullException.ThrowIfNull(configuration, nameof(configuration));

        var connectionString = configuration.GetConnectionString("customerDbDp");

        ArgumentException.ThrowIfNullOrEmpty(connectionString, nameof(connectionString));

        return new MySqlConnection(connectionString);
    }
}
