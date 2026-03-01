using Refit;
using WebBFF.Services.RestClients.Requests.Requests;

namespace WebBFF.Services.RestClients.Requests;

public interface IAuthServiceRestClient
{
    [Post("/auth/login")]
    public Task<string> Login([Body] AuthRequest request);
}