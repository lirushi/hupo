using Microsoft.AspNetCore.Identity;

namespace Hupo.Template.Domain.Identity;

public class ApplicationRoleClaim : IdentityRoleClaim<long>, IEntity
{
    public new long Id { get; set; }
    public virtual ApplicationRole Role { get; set; } = default!;
}
