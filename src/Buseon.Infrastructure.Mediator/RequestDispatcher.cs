using System.Diagnostics.CodeAnalysis;
using Buseon.Infrastructure.CQRS.Abstractions;
using Buseon.Infrastructure.CQRS.Abstractions.Handlers;
using Buseon.Infrastructure.Mediator.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Buseon.Infrastructure.Mediator;

[ExcludeFromCodeCoverage]
public class RequestDispatcher(IServiceProvider serviceProvider) : IRequestDispatcher
{
    public async Task<TResponse> ProcessAsync<TRequest, TResponse>(
        TRequest request,
        CancellationToken cancellationToken = default)
        where TRequest : IRequest<TResponse>
    {
        var handler = serviceProvider.GetRequiredService<IRequestHandler<TRequest, TResponse>>();

        return await handler.HandleAsync(request, cancellationToken);
    }
}