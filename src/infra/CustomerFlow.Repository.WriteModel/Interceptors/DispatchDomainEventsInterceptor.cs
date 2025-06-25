namespace CustomerFlow.Infra.CommandRepository.Interceptors;

public class DispatchDomainEventsInterceptor(
    IMediator mediator)
    : SaveChangesInterceptor
{
    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        var dbContext = eventData.Context;

        await DispatchDomainEvents(dbContext, cancellationToken);
        var resultSaveChange = await base.SavingChangesAsync(eventData, result, cancellationToken);

        return resultSaveChange;
    }

    private async Task DispatchDomainEvents(DbContext? dbContext, CancellationToken cancellationToken = default)
    {
        if (dbContext == null) return;

        var aggregates = dbContext.ChangeTracker
            .Entries<IAggregate>()
            .Where(x => x.Entity.DomainEvents.Any())
            .Select(x => x.Entity);

        var domainEvents = aggregates
            .SelectMany(x => x.DomainEvents)
            .ToList();

        aggregates.ToList().ForEach(x => x.ClearDomainEvents());

        foreach (var domainEvent in domainEvents)
        {
            await mediator.Publish(domainEvent, cancellationToken);
        }
    }

}
