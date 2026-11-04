using WebBFF.Infrastructure.Services.RestClients.Auth.Enums;

namespace WebBFF.Infrastructure.Services.RestClients.Auth.Responses;

public record UserDataResponse(Guid UserId, string Email, string FullName, JobTitle Title);