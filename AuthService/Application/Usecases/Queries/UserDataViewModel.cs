using AuthService.Domain.Enums;

namespace AuthService.Application.Usecases.Queries;

public record UserDataViewModel(Guid UserId, string Email, string FullName, JobTitle Title);