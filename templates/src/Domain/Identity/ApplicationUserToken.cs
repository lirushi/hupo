using Microsoft.AspNetCore.Identity;

namespace Hupo.Template.Domain.Identity;

public class ApplicationUserToken : IdentityUserToken<long>
{
    public virtual ApplicationUser User { get; set; } = default!;
}
