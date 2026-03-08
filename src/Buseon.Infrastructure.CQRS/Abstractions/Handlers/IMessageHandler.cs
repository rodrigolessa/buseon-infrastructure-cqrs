namespace Buseon.Infrastructure.CQRS.Abstractions.Handlers;

/// <summary>
/// Generic message handler abstraction, if you need to handle any message type.
/// </summary>
/// <typeparam name="TMessage">The type of the message.</typeparam>
public interface IMessageHandler<in TMessage>
    where TMessage : IMessage
{
    Task HandleAsync(TMessage message, CancellationToken cancellationToken = default);
}
