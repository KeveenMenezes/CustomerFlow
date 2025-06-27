namespace CustomerFlow.Infra.CommandRepository.Interceptors;

public class DispatchDomainEventsInterceptor(
    IMediator mediator)
    : SaveChangesInterceptor
{
    public override async ValueTask<int> SavedChangesAsync(
        SaveChangesCompletedEventData eventData,
        int result,
        CancellationToken cancellationToken = default)
    {
        var dbContext = eventData.Context;
        var savedChangesResult = await base.SavedChangesAsync(eventData, result, cancellationToken);
        await DispatchDomainEvents(dbContext, cancellationToken);
        return savedChangesResult;
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
