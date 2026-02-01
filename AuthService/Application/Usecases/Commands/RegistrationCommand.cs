using AuthService.Domain.Dto;
using AuthService.Domain.Enums;
using AuthService.Domain.Repositories.Interfaces;
using MediatR;

namespace AuthService.Application.Usecases.Commands;

public class RegistrationCommand : IRequest
{
    public string Email { get; set; }

    public string Password { get; set; }

    public string PhoneNumber { get; set; }

    public JobTitle Title { get; set; }

    private class Handler : IRequestHandler<RegistrationCommand>
    {
        private readonly IUserRepository _repository;

        public Handler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            await _repository.Register(new UserData(Guid.NewGuid(), request.Email, request.Password, request.PhoneNumber, request.Title, DateTime.Now));
        }
    }
}