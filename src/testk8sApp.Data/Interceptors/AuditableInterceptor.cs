using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using testK8sApp.Domain.Interfaces;

namespace testK8sApp.Data.Interceptors;

public class AuditableInterceptor : SaveChangesInterceptor
{
    private readonly Dictionary<EntityState, bool> _auditableStates = new()
    {
        { EntityState.Deleted, true },
        { EntityState.Modified, true },
    };

    public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        if (eventData.Context is null) return ValueTask.FromResult(result);

        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            if (entry is not { Entity: IAuditable auditable}) continue;
            if (!_auditableStates.ContainsKey(entry.State)) continue;

            if (entry.State == EntityState.Deleted)
            {
                auditable.DeletedAt = DateTime.Now;
                auditable.IsDeleted = true;
            }

            {
                auditable.UpdatedAt = DateTime.Now;
            }
            
            entry.State = EntityState.Modified;
        }

        return ValueTask.FromResult(result);
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        if (eventData.Context is null) return result;

        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            if (entry is not { Entity: IAuditable auditable}) continue;
            if (!_auditableStates.ContainsKey(entry.State)) continue;

            if (entry.State == EntityState.Deleted)
            {
                auditable.DeletedAt = DateTime.Now;
                auditable.IsDeleted = true;
            }

            {
                auditable.UpdatedAt = DateTime.Now;
            }
            
            entry.State = EntityState.Modified;
        }

        return result;
    }
}