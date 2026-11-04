using AutoMapper;
using MediatR;
using WebBFF.Infrastructure.Services.Auth;

namespace WebBFF.Application.Usecases.Commands.Auth;

public class AuthCommand : IRequest<string>
{
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    private class Handler : IRequestHandler<AuthCommand, string>
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public Handler(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<string> Handle(AuthCommand request, CancellationToken cancellationToken)
        {
            var token = await _authService.Login(request.Email, request.Password, cancellationToken);
            
            return token;
        }
    }
}