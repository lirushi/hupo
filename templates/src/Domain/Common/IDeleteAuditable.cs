namespace Hupo.Template.Domain.Common;

public interface IDeleteAuditable
{
    /// <summary>
    ///     Marks whether the current record has been deleted
    ///     <value>true deleted</value>
    /// </summary>
    bool IsDeleted { get; set; }

    DateTimeOffset? DeletedDate { get; set; }

    long? DeletedBy { get; set; }
}
