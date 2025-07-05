namespace CustomerFlow.Infra.QueryRepository.Configurations;

public class QueryRepositoryConfiguration
{
    public string QueryConnectionString { get; set; }
    public bool UsarSqlBulkCopy { get; set; }
}
