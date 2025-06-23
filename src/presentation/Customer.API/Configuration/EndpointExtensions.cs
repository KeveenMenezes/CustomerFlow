using System.Reflection;

namespace CustomerFlow.Presentation.API.Configuration;

public static class EndpointExtensions
{
    public static void MapAllEndpoints(this WebApplication app, Assembly assembly)
    {
        var endpointTypes = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract)
            .ToList();

        foreach (var type in endpointTypes)
        {
            var method = type.GetMethod(
                "MapEndpoint",
                BindingFlags.Public | BindingFlags.Static,
                null,
                new[] { typeof(WebApplication) },
                null);

            if (method != null)
            {
                try
                {
                    method.Invoke(null, new object[] { app });
                    Console.WriteLine($"Mapped endpoint from: {type.FullName}"); // Para debug
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to map endpoint {type.FullName}: {ex.Message}");
                }
            }
        }
    }
}
