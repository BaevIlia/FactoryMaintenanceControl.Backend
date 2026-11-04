using AutoMapper;
using WebBFF.Domain.Dtos;
using WebBFF.Infrastructure.Services.RestClients.Auth;

namespace WebBFF.Infrastructure.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IAuthServiceRestClient _restClient;
    private readonly IMapper _mapper;

    public AuthService(IAuthServiceRestClient restClient, IMapper mapper)
    {
        _restClient = restClient;
        _mapper = mapper;
    }

    public async Task<string> Login(string email, string password, CancellationToken cancellationToken)
    {
        var res = await _restClient.Auth(new(email, password), cancellationToken);

        return res;
    }

    public async Task<UserData> GetUserData(Guid userId, CancellationToken cancellationToken)
    {
        var response = await _restClient.GetUserData(userId, cancellationToken);
        
        return _mapper.Map<UserData>(response);
    }
}