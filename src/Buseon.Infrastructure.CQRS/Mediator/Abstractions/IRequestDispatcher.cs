using Buseon.Infrastructure.CQRS.Abstractions;

namespace Buseon.Infrastructure.CQRS.Mediator.Abstractions;

public interface IRequestDispatcher
{
    Task<TResponse> ProcessAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default)
        where TRequest : IRequest<TResponse>;
}