namespace Hupo.Template.Domain.Common;

public interface IConcurrencyStamp
{
    /// <summary>
    ///     A random value that must change whenever a user is persisted to the entity
    /// </summary>
    string? ConcurrencyStamp { get; set; }
}
