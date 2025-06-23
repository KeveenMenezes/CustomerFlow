using CustomerFlow.Core.Domain.Abstractions;
using CustomerFlow.Infra.CustomerIntegrationAdapter.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace CustomerFlow.Infra.CustomerIntegrationAdapter.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddCustomerIntegrationAdapterServices(
        this IServiceCollection services)
    {
        services.AddScoped<ICustomerIntegrationAdapter, CustomerIntegrationAdapter>();
        services.AddRefitClient<ICustomerIntegrationApi>();

        return services;
    }
}
