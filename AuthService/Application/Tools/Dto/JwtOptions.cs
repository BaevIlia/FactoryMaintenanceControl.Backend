namespace AuthService.Application.Tools.Dto;

public class JwtOptions
{
    public string SecretKey { get; set; }

    public double ExpiresHours { get; set; }
}