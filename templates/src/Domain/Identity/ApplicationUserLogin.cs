using Microsoft.AspNetCore.Identity;

namespace Hupo.Template.Domain.Identity;

public class ApplicationUserLogin : IdentityUserLogin<long>
{
    public virtual ApplicationUser User { get; set; } = default!;
}
