using AuthService.Application.Tools.Impl;
using AuthService.Application.Tools.Interfaces;
using AuthService.Domain.Entities;
using AuthService.Domain.Repositories.Interfaces;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace AuthService.Application.Usecases.Commands;

public class LoginCommand : IRequest<string>
{
    public string Email { get; set; }

    public string Password { get; set; }

    private class Handler : IRequestHandler<LoginCommand, string>
    {
        private readonly IPasswordHasher _hasher;
        private readonly IUserRepository _repository;
        private readonly ITokenProvider _provider;

        public Handler(IPasswordHasher hasher, IUserRepository repository, ITokenProvider provider)
        {
            _hasher = hasher;
            _repository = repository;
            _provider = provider;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByEmail(request.Email);

            var verifyResult = _hasher.Verify(request.Password, user.Password);

            if (verifyResult == false)
                throw new Exception("Неверно указана почта или пароль");

            var token = _provider.GenerateToken(user);

            return token;
        }
    }
}