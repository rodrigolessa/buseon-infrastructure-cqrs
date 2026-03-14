using Buseon.Infrastructure.CQRS.Abstractions;

namespace Buseon.Infrastructure.CQRS.Mediator.Abstractions;

public interface ICommandDispatcher
{
    Task DispatchAsync<TCommand>(TCommand command, CancellationToken cancellationToken)
        where TCommand : ICommand;
}   