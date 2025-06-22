using System.Reflection;
using CustomerFlow.Infra.CommandRepository.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerFlow.BuildingBlocks.Messaging.EventBusConfiguration;

public static class Extentions
{
    public static IServiceCollection AddMessageBroker(
        this IServiceCollection services,
        IConfiguration configuration,
        Assembly? assembly = null)
    {
        var kafkaHost = configuration["MessageBroker:Host"];

        if (string.IsNullOrEmpty(kafkaHost))
        {
            throw new ArgumentNullException(nameof(configuration), "MessageBroker:Host configuration is missing");
        }

        services.AddCap(options =>
        {
            options.UseEntityFramework<CustomerFlowDbContext>();

            options.UseKafka(kafkaOptions =>
            {
                kafkaOptions.Servers = kafkaHost;

                kafkaOptions.MainConfig.Add("group.id", "customerflow.group");
                kafkaOptions.MainConfig.Add("socket.timeout.ms", "6000");
                kafkaOptions.MainConfig.Add("session.timeout.ms", "3000");
                kafkaOptions.MainConfig.Add("auto.offset.reset", "earliest");
                kafkaOptions.MainConfig.Add("enable.auto.commit", "false");
            });

            options.FailedRetryCount = 5;
            options.FailedRetryInterval = 60;
            options.UseDashboard();

            options.SucceedMessageExpiredAfter = 24 * 3600; // 1 day
        });

        return services;
    }
}
