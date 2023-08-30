namespace Hupo.Template.Domain.Common;

public interface ICreateAuditable
{
    DateTimeOffset CreatedTime { get; set; }

    long? CreatedBy { get; set; }
}
