namespace Buseon.Infrastructure.CQRS.Abstractions.Handlers;

/// <summary>
/// Handles a command.
/// </summary>
/// <typeparam name="TCommand">The type of the command.</typeparam>
public interface ICommandHandler<in TCommand>
    where TCommand : ICommand
{
    Task HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}