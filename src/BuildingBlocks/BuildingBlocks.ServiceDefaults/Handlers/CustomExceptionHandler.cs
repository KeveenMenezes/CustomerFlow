namespace BuildingBlocks.ServiceDefaults.Handlers;

public class CustomExceptionHandler
    (ILogger<CustomExceptionHandler> logger)
    : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        logger.LogError(
            "Error Message: {ExceptionMessage}, Time of occurrence {Time}",
            exception.Message, DateTime.UtcNow);

        (var Detail, var ErrorCode, var StatusCode) = exception switch
        {
            NotFoundException =>
            (
                exception.Message,
                exception.GetType().Name,
                StatusCodes.Status404NotFound
            ),
            ValidationException =>
            (
                exception.Message,
                exception.GetType().Name,
                StatusCodes.Status400BadRequest
            ),
            BadRequestException =>
            (
                exception.Message,
                exception.GetType().Name,
                StatusCodes.Status400BadRequest
            ),
            DomainException =>
            (
                exception.Message,
                exception.GetType().Name,
                StatusCodes.Status422UnprocessableEntity
            ),
            InternalServerException =>
            (
                exception.Message,
                exception.GetType().Name,
                StatusCodes.Status500InternalServerError
            ),
            _ =>
            (
                exception.Message,
                exception.GetType().Name,
                StatusCodes.Status500InternalServerError
            )
        };

        var errors = new List<ErrorDto>
        {
            new(null, Detail, ErrorCode)
        };

        if (exception is ValidationException validationException && validationException.Errors is not null)
        {
            errors = [.. validationException.Errors.Select(e =>
                new ErrorDto(e.PropertyName, e.ErrorMessage, ErrorCode))];
        }

        var dataResult = new DataResult(false, errors);

        httpContext.Response.StatusCode = StatusCode;
        await httpContext.Response.WriteAsJsonAsync(dataResult, cancellationToken);
        return true;
    }
}
