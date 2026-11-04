using System.Security.Claims;

namespace WebBFF.Infrastructure.Services.User;

public class UserService : IUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Guid> GetUserId(CancellationToken cancellationToken = default)
    {
        var userIdString = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        return Guid.Parse(userIdString);
    }
}