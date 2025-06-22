namespace CustomerFlow.Infra.CommandRepository.Configuration;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICustomerCommandRepository, CustomerCommandRepository>();

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        services.AddDbContext<CustomerFlowDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseMySql(
                configuration.GetConnectionString("customerDb"),
                ServerVersion.AutoDetect(configuration.GetConnectionString("customerDb"))
            );
        });

        return services;
    }
}
