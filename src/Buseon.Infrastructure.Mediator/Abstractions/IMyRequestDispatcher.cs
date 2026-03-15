using Buseon.Infrastructure.CQRS.Abstractions;

namespace Buseon.Infrastructure.Mediator.Abstractions;

public interface IMyRequestDispatcher
{
    Task<TResponse> ProcessAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default)
        where TRequest : IMyRequest<TResponse>;
}