namespace Shared.EventBus;

public abstract class InternalEvent
{
    public Guid EventId { get; set; }
}