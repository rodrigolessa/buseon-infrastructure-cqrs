using Buseon.Infrastructure.CQRS.Abstractions;

namespace Buseon.Infrastructure.Mediator.Abstractions;

/// <summary>
/// Desacoplar request e handler
/// </summary>
public interface ICommandDispatcher
{
    Task DispatchAsync<TCommand>(TCommand command, CancellationToken cancellationToken)
        where TCommand : ICommand;
}   