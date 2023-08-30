using Microsoft.AspNetCore.Identity;

namespace Hupo.Template.Domain.Identity;

public class ApplicationUserClaim : IdentityUserClaim<long>, IEntity
{
    public new long Id { get; set; }

    public virtual ApplicationUser User { get; set; } = default!;
}


