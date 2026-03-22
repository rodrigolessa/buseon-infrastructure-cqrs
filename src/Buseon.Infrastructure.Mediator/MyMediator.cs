using Buseon.Infrastructure.Abstractions;
using Buseon.Infrastructure.Mediator.Abstractions;
using Buseon.Infrastructure.Mediator.Registration;
using Microsoft.Extensions.DependencyInjection;

namespace Buseon.Infrastructure.Mediator;

public sealed class MyMediator
{
    private readonly MyHandlerRegistry _registry;

    public MyMediator(MyHandlerRegistry registry)
    {
        _registry = registry;
    }

    public Task<TResponse> SendAsync<TResponse>(
        IMyRequest<TResponse> request,
        CancellationToken ct = default)
    {
        var handler = _registry.Get(request.GetType());

        return handler(request, ct)
            .ContinueWith(t => (TResponse)t.Result!, ct);
    }
}

public class OldMediator(IServiceProvider provider) : IMyMediator
{
    public Task<TResponse> SendAsync<TResponse>(
        IMyRequest<TResponse> request,
        CancellationToken cancellationToken = default)
    {
        var requestType = request.GetType();

        var executorType = typeof(IMyRequestDispatcher<,>)
            .MakeGenericType(requestType, typeof(TResponse));

        dynamic executor = provider.GetRequiredService(executorType);

        return executor.Execute((dynamic)request, cancellationToken);
    }
}