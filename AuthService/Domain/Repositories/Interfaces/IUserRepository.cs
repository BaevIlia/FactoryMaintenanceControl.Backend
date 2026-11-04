using AuthService.Domain.Dto;
using AuthService.Domain.Entities;

namespace AuthService.Domain.Repositories.Interfaces;

public interface IUserRepository
{
    Task Register(UserData data, CancellationToken cancellationToken);

    Task<User> GetByEmail(string email, CancellationToken cancellationToken);

    Task<User> GetById(Guid id, CancellationToken cancellationToken);
}