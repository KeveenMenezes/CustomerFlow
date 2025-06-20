using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CustomerFlow.BuildingBlocks.ServiceDefaults.Filters;

public class ApiResponseFilter
    : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Result is ObjectResult objectResult)
        {
            // Exemplo: padroniza resposta de sucesso
            if (objectResult.StatusCode is null or >= 200 and < 300)
            {
                context.Result = new OkObjectResult(new DataResult<object?>(objectResult.Value, true));
            }
            // Exemplo: padroniza resposta de erro
            else if (objectResult.StatusCode is >= 400)
            {
                context.Result = new BadRequestObjectResult(new DataResult(false, objectResult.Value?.ToString()));
            }
        }
        else if (context.Result is EmptyResult)
        {
            context.Result = new OkObjectResult(new DataResult(true));
        }
    }
}


public sealed record DataResult<T>(T Data, bool Success, List<ErrorDto>? Errors = null);

public sealed record DataResult(bool Success, List<ErrorDto>? Errors = null)
{
    public DataResult(bool success, string? error)
    : this(success, [new(error ?? string.Empty)])
    {
    }
}


public sealed record ErrorDto(string? EntityId, string ErrorMessage, string? ErrorCode)
{
    public ErrorDto(string message) : this(null, message, null) { }

    [JsonConstructor]
    public ErrorDto(string entityId, string message) : this(entityId, message, null) { }
};
