using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Hupo.Template.Infrastructure.Data.Interceptors;

public class ModifyAuditableInterceptors : SaveChangesInterceptor
{
    private readonly ICurrentUser _user;

    public ModifyAuditableInterceptors(ICurrentUser user)
    {
        _user = user;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void UpdateEntities(DbContext? context)
    {
        if (context == null) {
            return;
        }

        foreach (var entry in context.ChangeTracker.Entries<IModifyAuditable>()) {
            if (entry.State != EntityState.Modified && !entry.HasChangedOwnedEntities(EntityState.Modified)) {
                continue;
            }
            entry.Entity.LastModifiedBy = _user.Id;
            entry.Entity.LastModifiedDate = DateTimeOffset.UtcNow;
        }
    }
}
