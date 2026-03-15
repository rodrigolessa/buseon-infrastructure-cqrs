namespace Buseon.Infrastructure.Abstractions;

public interface IMyRequestHandler<in TRequest, TResponse>
    where TRequest : IMyRequest<TResponse>
{
    Task<TResponse> HandleAsync(
        TRequest request,
        CancellationToken cancellationToken);
}