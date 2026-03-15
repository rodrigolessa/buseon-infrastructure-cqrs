using Buseon.Infrastructure.Abstractions;

namespace Buseon.Infrastructure.CQRS.Abstractions.Handlers;

/// <summary>
/// Handles a command.
/// </summary>
/// <typeparam name="TCommand">The type of the command.</typeparam>
public interface IMyCommandHandler<in TCommand>
    where TCommand : IMyCommand
{
    Task HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}