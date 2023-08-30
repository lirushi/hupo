using Microsoft.AspNetCore.Identity;

namespace Hupo.Template.Domain.Identity;

public class ApplicationUserRole : IdentityUserRole<long>
{
    public virtual ApplicationUser User { get; set; } = default!;
    public virtual ApplicationRole Role { get; set; } = default!;
}
