using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Hupo.Template.Infrastructure.Data.Interceptors;

public class DeleteAuditableInterceptor : SaveChangesInterceptor
{
    private readonly ICurrentUser _user;

    public DeleteAuditableInterceptor(ICurrentUser user)
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

        foreach (var entry in context.ChangeTracker.Entries<IDeleteAuditable>()) {
            if (entry.State != EntityState.Deleted && !entry.HasChangedOwnedEntities(EntityState.Deleted)) {
                continue;
            }
            entry.State = EntityState.Modified;
            entry.Entity.IsDeleted = true;
            entry.Entity.DeletedBy = _user.Id;
            entry.Entity.DeletedDate = DateTimeOffset.UtcNow;
        }
    }
}
