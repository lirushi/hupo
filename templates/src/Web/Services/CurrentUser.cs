using System.Security.Claims;

namespace Hupo.Template.Web.Services;

public class CurrentUser : ICurrentUser
{
    private readonly ClaimsPrincipal? _user;
    private long _id;
    private bool _initialized;

    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        _user = httpContextAccessor.HttpContext?.User;
    }

    /// <inheritdoc />
    public bool IsAuthenticated => _user?.Identity?.IsAuthenticated ?? false;

    /// <inheritdoc />
    public long? Id
    {
        get
        {
            if (_initialized) {
                return _id;
            }
            _initialized = true;
            var value = _user?.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!value.IsNullOrWhiteSpace() && long.TryParse(value, out var id)) {
                _id = id;
            }
            return _id;
        }
    }
}
