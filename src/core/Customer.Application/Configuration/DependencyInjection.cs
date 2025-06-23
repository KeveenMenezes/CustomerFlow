using System.Reflection;
using CustomerFlow.BuildingBlocks.Messaging.EventBusConfiguration;
using CustomerFlow.BuildingBlocks.ServiceDefaults.Behaviors;
using CustomerFlow.Core.Application.Features.Customers.Commands.CreateCustomer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;

namespace CustomerFlow.Core.Application.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services
            .AddMessageBroker(configuration, assembly)
            .AddMediator(config =>
            {
                config.ServiceLifetime = ServiceLifetime.Scoped;
                config.PipelineBehaviors = [typeof(ValidationBehavior<,>), typeof(LoggingBehavior<,>)];
            })
            .AddValidatorsFromAssembly(assembly)
            .AddFeatureManagement(configuration);

        return services;
    }
}
