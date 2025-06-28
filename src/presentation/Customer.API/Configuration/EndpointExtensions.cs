using System.Reflection;

namespace CustomerFlow.Presentation.API.Configuration;

public static class EndpointExtensions
{
    public static void MapAllEndpoints(this WebApplication app)
    {
        var endpointTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.IsAssignableTo(typeof(IEndpoint))
            && !t.IsInterface
            && !t.IsAbstract);

        foreach (var type in endpointTypes)
        {
            // Correção: Invocação correta do método estático
            var mapMethod = type.GetMethod(
                "MapEndpoint",
                BindingFlags.Public | BindingFlags.Static,
                [typeof(WebApplication)]
            );

            mapMethod?.Invoke(null, [app]);
        }
    }
}
