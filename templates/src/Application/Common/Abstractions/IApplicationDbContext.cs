using Hupo.Template.Domain.Identity;

namespace Hupo.Template.Application.Common.Abstractions;

public interface IApplicationDbContext
{
    DbSet<ApplicationUser> Users { get; }
    DbSet<ApplicationRole> Roles { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
