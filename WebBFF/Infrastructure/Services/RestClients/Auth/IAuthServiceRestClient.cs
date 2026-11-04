using Microsoft.AspNetCore.Identity.Data;
using Refit;
using WebBFF.Infrastructure.Services.RestClients.Auth.Requests;
using WebBFF.Infrastructure.Services.RestClients.Auth.Responses;

namespace WebBFF.Infrastructure.Services.RestClients.Auth;

public interface IAuthServiceRestClient
{
    [Post("/auth/login")]
    public Task<string> Auth([Body] AuthRequest request, CancellationToken cancellationToken);
    
    [Get("/auth/userData")]
    public Task<UserDataResponse> GetUserData([Query]Guid userId, CancellationToken cancellationToken); 
}