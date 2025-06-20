namespace CustomerFlow.BuildingBlocks.ServiceDefaults.Behaviors;

public class HttpContextScopeBehavior(IHttpContextAccessor httpContextAccessor) :
    IFilter<PublishContext>,
    IFilter<SendContext>,
    IFilter<ConsumeContext>
{
    public Task Send(ConsumeContext context, IPipe<ConsumeContext> next)
    {
        AddPayload(context);
        return next.Send(context);
    }

    public Task Send(PublishContext context, IPipe<PublishContext> next)
    {
        AddPayload(context);
        return next.Send(context);
    }

    public Task Send(SendContext context, IPipe<SendContext> next)
    {
        AddPayload(context);
        return next.Send(context);
    }

    public void Probe(ProbeContext context)
    {
    }

    void AddPayload(PipeContext context)
    {
        if (httpContextAccessor.HttpContext == null)
            return;

        var serviceProvider = httpContextAccessor.HttpContext.RequestServices;
        context.GetOrAddPayload(() => serviceProvider);
        context.GetOrAddPayload<IServiceScope>(() => new NoopScope(serviceProvider));
    }

    class NoopScope(IServiceProvider serviceProvider) :
        IServiceScope
    {
        public void Dispose()
        {
        }

        public IServiceProvider ServiceProvider { get; } = serviceProvider;
    }
}
