using Buseon.Infrastructure.Abstractions;
using Buseon.Infrastructure.Mediator.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Buseon.Infrastructure.Mediator;

public class MyMediator(IServiceProvider provider) : IMyMediator
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