using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Hupo.Template.Infrastructure.Data.Interceptors;

public class CreateAuditableInterceptor : SaveChangesInterceptor
{
    private readonly ICurrentUser _user;

    public CreateAuditableInterceptor(ICurrentUser user)
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
        foreach (var entry in context.ChangeTracker.Entries<ICreateAuditable>()) {
            if (entry.State != EntityState.Added && !entry.HasChangedOwnedEntities(EntityState.Added)) {
                continue;
            }
            entry.Entity.CreatedBy = _user.Id;
            entry.Entity.CreatedTime = DateTimeOffset.UtcNow;
        }
    }
}
