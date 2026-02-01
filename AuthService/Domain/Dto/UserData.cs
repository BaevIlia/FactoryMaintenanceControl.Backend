using AuthService.Domain.Enums;

namespace AuthService.Domain.Dto;

public record UserData(Guid Id, string Email, string Password, string PhoneNumber, JobTitle Title, DateTime RegistrationDate);