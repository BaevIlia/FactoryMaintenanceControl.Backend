using RequestsService.Domain.Entities;
using RequestsService.Domain.Repositories.Interfaces;
using RequestsService.Infrastructure;

namespace RequestsService.Domain.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private readonly RequestDbContext _context;

    public UserRepository(RequestDbContext context)
    {
        _context = context;
    }

    public async Task Add(UserEntity entity)
    {
        _context.Users.Add(entity);

        await _context.SaveChangesAsync();
    }
}