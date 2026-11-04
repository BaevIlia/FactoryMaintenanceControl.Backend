using WebBFF.Domain.Dtos;

namespace WebBFF.Infrastructure.Services.Auth;

public interface IAuthService
{
    Task<string> Login(string email, string password, CancellationToken cancellationToken);

    Task<UserData> GetUserData(Guid userId, CancellationToken cancellationToken);
}