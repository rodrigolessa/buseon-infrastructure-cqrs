using System.Diagnostics.CodeAnalysis;
using Buseon.Infrastructure.CQRS.Abstractions;
using Buseon.Infrastructure.CQRS.Abstractions.Handlers;
using Buseon.Infrastructure.Mediator.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Buseon.Infrastructure.Mediator;

[ExcludeFromCodeCoverage]
public class MyRequestDispatcher(IServiceProvider serviceProvider) : IMyRequestDispatcher
{
    public async Task<TResponse> ProcessAsync<TRequest, TResponse>(
        TRequest request,
        CancellationToken cancellationToken = default)
        where TRequest : IMyRequest<TResponse>
    {
        var handler = serviceProvider.GetRequiredService<IMyRequestHandler<TRequest, TResponse>>();

        return await handler.HandleAsync(request, cancellationToken);
    }
}