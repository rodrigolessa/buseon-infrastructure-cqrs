namespace Buseon.Infrastructure.CQRS.Abstractions.Handlers;

/// <summary>
/// Handles an event.
/// </summary>
/// <typeparam name="TEvent">The type of the event.</typeparam>
public interface IMyEventHandler<in TEvent>
    where TEvent : IMyEvent
{
    Task HandleAsync(TEvent @event, CancellationToken cancellationToken = default);
}
