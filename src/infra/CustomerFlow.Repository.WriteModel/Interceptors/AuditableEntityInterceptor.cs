using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CustomerFlow.Infra.CommandRepository.Interceptors;

public class AuditableEntityInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private static void UpdateEntities(DbContext? context)
    {
        if (context == null) return;

        foreach (var entity in context.ChangeTracker.Entries<IEntity>())
        {
            if (entity.State == EntityState.Added)
            {
                entity.Entity.CreatedAt = DateTime.UtcNow;
            }

            if (entity.State == EntityState.Added ||
                entity.State == EntityState.Modified ||
                entity.HasChangedOwnedEntities())
            {
                entity.Entity.LastModified = DateTime.UtcNow;
                entity.Entity.LastModifiedBy = "system";
            }
        }
    }
}

public static class Extensions
{
    public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
        entry.References.Any(r =>
            r.TargetEntry != null
            && r.TargetEntry.Metadata.IsOwned()
            && (r.TargetEntry.State == EntityState.Added
                || r.TargetEntry.State == EntityState.Modified));
}
