using Buseon.Infrastructure.Abstractions;

namespace Buseon.Infrastructure.Mediator.Abstractions;  

public interface IMyRequestDispatcher<in TRequest, TResponse>
    where TRequest : IMyRequest<TResponse>
{
    Task<TResponse> DispatchAsync(
        TRequest request,
        CancellationToken cancellationToken);
}

// public interface IMyRequestDispatcher
// {   
//     Task<TResponse> ProcessAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default) where TRequest : IMyRequest<TResponse>;
// }