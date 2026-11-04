namespace WebBFF.Infrastructure.Services.User;

public interface IUserService
{
    Task<Guid> GetUserId(CancellationToken cancellationToken);
}