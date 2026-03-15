namespace Buseon.Infrastructure.Abstractions;

public interface IMyMediator
{
    Task<TResponse> SendAsync<TResponse>(
        IMyRequest<TResponse> request,
        CancellationToken cancellationToken = default);
}