namespace Hupo.Template.Domain.Common;

public abstract class AuditableEntity : BaseEntity, IConcurrencyStamp, ICreateAuditable, IModifyAuditable, IDeleteAuditable
{
    /// <inheritdoc />
    public string? ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

    /// <inheritdoc />
    public DateTimeOffset CreatedTime { get; set; }

    /// <inheritdoc />
    public long? CreatedBy { get; set; }

    /// <inheritdoc />
    public bool IsDeleted { get; set; }

    /// <inheritdoc />
    public DateTimeOffset? DeletedDate { get; set; }

    /// <inheritdoc />
    public long? DeletedBy { get; set; }

    /// <inheritdoc />
    public DateTimeOffset? LastModifiedDate { get; set; }

    /// <inheritdoc />
    public long? LastModifiedBy { get; set; }
}
