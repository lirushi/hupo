namespace Hupo.Template;

public interface ICurrentUser
{
    bool IsAuthenticated { get; }

    long? Id { get; }
}
