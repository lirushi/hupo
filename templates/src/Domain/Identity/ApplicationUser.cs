using Microsoft.AspNetCore.Identity;

namespace Hupo.Template.Domain.Identity;

public class ApplicationUser : IdentityUser<long>, IEntity, IConcurrencyStamp, ICreateAuditable, IModifyAuditable, IDeleteAuditable
{
    /// <inheritdoc />
    public DateTimeOffset CreatedTime { get; set; }

    /// <inheritdoc />
    public long? CreatedBy { get; set; }

    /// <inheritdoc />
    public DateTimeOffset? LastModifiedDate { get; set; }

    /// <inheritdoc />
    public long? LastModifiedBy { get; set; }

    /// <inheritdoc />
    public bool IsDeleted { get; set; }

    /// <inheritdoc />
    public DateTimeOffset? DeletedDate { get; set; }

    /// <inheritdoc />
    public long? DeletedBy { get; set; }

    public virtual ICollection<ApplicationUserClaim> Claims { get; set; } = new HashSet<ApplicationUserClaim>();
    public virtual ICollection<ApplicationUserLogin> Logins { get; set; } = new HashSet<ApplicationUserLogin>();
    public virtual ICollection<ApplicationUserToken> Tokens { get; set; } = new HashSet<ApplicationUserToken>();
    public virtual ICollection<ApplicationUserRole> UserRoles { get; set; } = new HashSet<ApplicationUserRole>();
}
