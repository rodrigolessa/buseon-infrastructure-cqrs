using Buseon.Infrastructure.CQRS.Abstractions;
using Buseon.Infrastructure.CQRS.Abstractions.Handlers;
using Buseon.Infrastructure.Mediator.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Buseon.Infrastructure.Mediator;

public class MyCommandDispatcher(IServiceProvider serviceProvider) : IMyCommandDispatcher
{
    public async Task DispatchAsync<TCommand>(TCommand command, CancellationToken cancellationToken)
        where TCommand : IMyCommand
    {
        var handler = serviceProvider.GetRequiredService<IMyCommandHandler<TCommand>>();

        await handler.HandleAsync(command, cancellationToken);
    }
}