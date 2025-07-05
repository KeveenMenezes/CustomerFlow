using CustomerFlow.BuildingBlocks.ServiceDefaults.QueriesAbstractions;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerFlow.Infra.QueryRepository.Configurations;

public static class QueryRepositoryDependency
{
    public static IServiceCollection AddQueryRepositoryServices(
        this IServiceCollection services)
    {
        services.AddScoped<IQueryRepository, Repositories.QueryRepository>();
        return services;
    }
}
