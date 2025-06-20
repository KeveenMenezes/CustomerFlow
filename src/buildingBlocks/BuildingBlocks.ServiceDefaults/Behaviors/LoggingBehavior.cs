namespace CustomerFlow.BuildingBlocks.ServiceDefaults.Behaviors;

public class LoggingBehavior<TRequest, TResponse>
    (ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, IRequest<TResponse>
    where TResponse : notnull
{
    public async ValueTask<TResponse> Handle(
        TRequest message,
        CancellationToken cancellationToken,
        MessageHandlerDelegate<TRequest, TResponse> next)
    {
        logger.LogInformation(
            @"[START] Handle request= {Request}
            Response= {Response}
            ResquestData= {RequestData}",
            typeof(TRequest).Name, typeof(TResponse).Name, message);

        var timer = new Stopwatch();

        timer.Start();
        var response = await next(message, cancellationToken);
        timer.Stop();

        var timeTaken = timer.Elapsed;
        if (timeTaken.Seconds > 3)
        {
            logger.LogWarning("[PERFORAMANCE] The request {Request} took {TimeTaken} seconds",
                typeof(TRequest).Name, timeTaken.Seconds);
        }

        logger.LogInformation(
            @"[END] Handle request={Request}
            Response={Response}
            ResquestData={RequestData}",
            typeof(TRequest).Name, typeof(TResponse).Name, message);

        return response;
    }
}
