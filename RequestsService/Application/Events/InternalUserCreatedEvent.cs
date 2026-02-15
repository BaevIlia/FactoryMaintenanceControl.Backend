using Rebus.Handlers;
using RequestsService.Domain.Entities;
using RequestsService.Domain.Enums;
using RequestsService.Domain.Repositories.Interfaces;
using Shared.EventBus;

namespace RequestsService.Application.Events;

public class InternalUserCreatedEvent : InternalEvent
{
    public Guid Id { get; set; }

    public string FullName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public JobTitle Title { get; set; }

    public class Handler : IHandleMessages<InternalUserCreatedEvent>
    {
        private readonly IUserRepository _repository;

        public Handler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(InternalUserCreatedEvent message)
        {
            var entity = new UserEntity
            {
                FullName = message.FullName,
                Email = message.Email,
                Phone = message.PhoneNumber,
                JobTitle = message.Title
            };

            await _repository.Add(entity);
        }
    }
}