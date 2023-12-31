using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using testK8sApp.Domain.Interfaces;

namespace testK8sApp.Data.Interceptors;

public class AuditableInterceptor : SaveChangesInterceptor
{
    private readonly string _user;
    
    private readonly Dictionary<EntityState, bool> _auditableStates = new()
    {
        { EntityState.Deleted, true },
        { EntityState.Modified, true },
    };

    public AuditableInterceptor(string user)
    {
        this._user = user;
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData, 
        InterceptionResult<int> result,
        CancellationToken cancellationToken = new())
    {
        if (eventData.Context is null) return ValueTask.FromResult(result);

        foreach (EntityEntry entry in eventData.Context.ChangeTracker.Entries())
        {
            if (entry is not { Entity: IAuditable auditable}) continue;
            if (!_auditableStates.ContainsKey(entry.State)) continue;

            if (entry.State == EntityState.Deleted)
            {
                auditable.DeletedAt = DateTime.UtcNow;
                auditable.IsDeleted = true;
            }
            else
            {
                auditable.UpdatedAt = DateTime.UtcNow;
            }

            auditable.UpdatedBy = _user;
            entry.State = EntityState.Modified;
        }

        return ValueTask.FromResult(result);
    }
}