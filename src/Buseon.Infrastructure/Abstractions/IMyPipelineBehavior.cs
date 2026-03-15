namespace Buseon.Infrastructure.Abstractions;

public interface IMyPipelineBehavior<in TRequest, TResponse>
{
    Task<TResponse> HandleAsync(
        TRequest request,
        MyRequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken);
}