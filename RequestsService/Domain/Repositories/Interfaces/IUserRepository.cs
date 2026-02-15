using RequestsService.Domain.Entities;

namespace RequestsService.Domain.Repositories.Interfaces;

public interface IUserRepository
{
    Task Add(UserEntity entity);
}