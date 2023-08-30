using Microsoft.AspNetCore.Identity;

namespace Hupo.Template.Domain.Identity;

public class ApplicationRole : IdentityRole<long>, IEntity, IConcurrencyStamp, ICreateAuditable, IModifyAuditable, IDeleteAuditable
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

    public virtual ICollection<ApplicationRoleClaim> Claims { get; set; } = new HashSet<ApplicationRoleClaim>();
    public virtual ICollection<ApplicationUserRole> UserRoles { get; set; } = new HashSet<ApplicationUserRole>();
}
