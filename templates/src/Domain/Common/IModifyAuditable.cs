namespace Hupo.Template.Domain.Common;

public interface IModifyAuditable
{
    DateTimeOffset? LastModifiedDate { get; set; }

    long? LastModifiedBy { get; set; }
}
