namespace CustomerFlow.Infra.CommandRepository.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICustomerCommandRepository, CustomerCommandRepository>();
        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        var connection = configuration.GetConnectionString("customerDb");
        services.AddDbContext<CustomerFlowDbContext>((sp, options) =>
        {
            try
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                options.UseMySql(connection, ServerVersion.AutoDetect(connection),
                    mysqlOptions =>
                    {
                        mysqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null);
                    })
                    .EnableDetailedErrors()
                    .EnableSensitiveDataLogging();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Falha ao configurar DbContext: {ex.Message}");
                throw;
            }
        });

        return services;
    }
}
