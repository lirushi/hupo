namespace Hupo.Template.Domain.Common;

public abstract class BaseEntity : IEntity
{
    /// <summary>
    ///     entity key
    /// </summary>
    public long Id { get; set; }
}
