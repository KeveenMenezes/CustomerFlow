namespace BuildingBlocks.ServiceDefaults.Behaviors;

public class LoggingBehavior<TRequest, TResponse>
    (ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    : IFilter<SendContext<TRequest>>
    where TRequest : class
    where TResponse : notnull
{
    public void Probe(ProbeContext context)
    {
        throw new NotImplementedException();
    }

    public async Task Send(SendContext<TRequest> context, IPipe<SendContext<TRequest>> next)
    {
        var request = context.Message;

        logger.LogInformation(
            @"[START] Handle request= {Request}
            Response= {Response}
            ResquestData= {RequestData}",
            typeof(TRequest).Name, typeof(TResponse).Name, request);

        var timer = new Stopwatch();

        timer.Start();
        await next.Send(context);
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
            typeof(TRequest).Name, typeof(TResponse).Name, request);
    }
}
