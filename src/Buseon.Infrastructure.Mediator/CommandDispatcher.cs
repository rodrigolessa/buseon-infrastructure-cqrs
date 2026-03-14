using Buseon.Infrastructure.CQRS.Abstractions;
using Buseon.Infrastructure.CQRS.Abstractions.Handlers;
using Buseon.Infrastructure.Mediator.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Buseon.Infrastructure.Mediator;

public class CommandDispatcher(IServiceProvider serviceProvider) : ICommandDispatcher
{
    public async Task DispatchAsync<TCommand>(TCommand command, CancellationToken cancellationToken)
        where TCommand : ICommand
    {
        var handler = serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();

        await handler.HandleAsync(command, cancellationToken);
    }
}