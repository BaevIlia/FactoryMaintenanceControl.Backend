using AuthService.Domain.Entities;

namespace AuthService.Application.Tools.Impl;

public interface ITokenProvider
{
    string GenerateToken(User user);
}