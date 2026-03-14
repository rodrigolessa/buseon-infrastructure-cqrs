using Buseon.Infrastructure.Mediator.Abstractions;

namespace Buseon.Infrastructure.Mediator.Abstractions;

/// <summary>
/// Desacoplar request e handler
/// </summary>
public interface IRequestDispatcher
{
    Task<TResponse> ProcessAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default)
        where TRequest : IRequest<TResponse>;
}