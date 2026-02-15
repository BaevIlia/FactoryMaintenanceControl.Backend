using AuthService.Domain.Enums;
using Shared.EventBus;

namespace AuthService.Application.Events;

public class InternalUserCreatedEvent : InternalEvent
{
    public Guid Id { get; set; }

    public string FullName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public JobTitle Title { get; set; }
}