using AuthService.Application.Tools.Interfaces;

namespace AuthService.Application.Tools.Impl;

public class PasswordHasher : IPasswordHasher
{
    public string Hash(string password) 
        => BCrypt.Net.BCrypt.EnhancedHashPassword(password);

    public bool Verify(string password, string hashedPassword) 
        => BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
}