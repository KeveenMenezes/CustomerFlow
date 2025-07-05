using MySql.Data.MySqlClient;

namespace CustomerFlow.BuildingBlocks.ServiceDefaults.QueriesAbstractions;

public interface IQueryRepository
{
    MySqlConnection CreateConnectionAsync(CancellationToken cancellationToken);
}
