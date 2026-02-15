using AuthService.Application.Events;
using AuthService.Domain.Dto;
using AuthService.Domain.Enums;
using AuthService.Domain.Repositories.Interfaces;
using MediatR;
using Newtonsoft.Json;
using Rebus.Bus;

namespace AuthService.Application.Usecases.Commands;

public class RegistrationCommand : IRequest
{
    public string Email { get; set; }

    public string Password { get; set; }

    public string FullName { get; set; }

    public string PhoneNumber { get; set; }

    public JobTitle Title { get; set; }

    private class Handler : IRequestHandler<RegistrationCommand>
    {
        private readonly IUserRepository _repository;
        private readonly IBus _bus;

        public Handler(IUserRepository repository, IBus bus)
        {
            _repository = repository;
            _bus = bus;
        }

        public async Task Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            var newUser = new UserData(Guid.NewGuid(), request.Email, request.Password, request.FullName, request.PhoneNumber, request.Title, DateTime.Now);

            await _repository.Register(newUser);

            var @event = new InternalUserCreatedEvent
            {
                EventId = Guid.NewGuid(),
                Id = newUser.Id,
                Email = newUser.Email,
                FullName = newUser.FullName,
                PhoneNumber = newUser.PhoneNumber,
                Title = newUser.Title,
            };

            await _bus.Send(@event);
        }
    }
}