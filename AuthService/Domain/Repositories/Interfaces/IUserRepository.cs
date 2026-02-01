using AuthService.Domain.Dto;

namespace AuthService.Domain.Repositories.Interfaces;

public interface IUserRepository
{
    Task Register(UserData data);
}