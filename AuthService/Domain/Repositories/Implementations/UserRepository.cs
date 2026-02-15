using AuthService.Domain.Dto;
using AuthService.Domain.Entities;
using AuthService.Domain.Repositories.Interfaces;
using AuthService.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Domain.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private readonly AuthDbContext _context;

    public UserRepository(AuthDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetByEmail(string email)
    {
        var res = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        return res;
    }

    public async Task Register(UserData data)
    {
        var userEntity = new User
        {
            Id = data.Id,
            FullName = data.FullName,
            Email = data.Email,
            Password = data.Password,
            PhoneNumber = data.PhoneNumber,
            Title = data.Title,
            RegistrationDate = data.RegistrationDate
        };

        _context.Users.Add(userEntity);

        await _context.SaveChangesAsync();
    }
}