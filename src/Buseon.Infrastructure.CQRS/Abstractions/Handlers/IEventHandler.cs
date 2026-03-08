namespace Buseon.Infrastructure.CQRS.Abstractions.Handlers;

/// <summary>
/// Handles an event.
/// </summary>
/// <typeparam name="TEvent">The type of the event.</typeparam>
public interface IEventHandler<in TEvent>
    where TEvent : IEvent
{
    Task HandleAsync(TEvent @event, CancellationToken cancellationToken = default);
}
