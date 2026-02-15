using AuthService.Domain.Dto;
using AuthService.Domain.Entities;

namespace AuthService.Domain.Repositories.Interfaces;

public interface IUserRepository
{
    Task Register(UserData data);

    Task<User> GetByEmail(string email);
}