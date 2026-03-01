using MediatR;
using WebBFF.Services.RestClients.Requests;
using WebBFF.Services.RestClients.Requests.Requests;

namespace WebBFF.Usecases.Command.Auth;

public class AuthCommand(string email, string password) : IRequest<string>
{
    public string Email { get; set; } = email;

    public string Password { get; set; } = password;

    private class Handler : IRequestHandler<AuthCommand, string>
    {
        private readonly IAuthServiceRestClient _client;

        public Handler(IAuthServiceRestClient client)
        {
            _client = client;
        }

        public async Task<string> Handle(AuthCommand request, CancellationToken cancellationToken)
        {
            var token = await _client.Login(new AuthRequest(request.Email, request.Password));

            return token;
        }
    }
}