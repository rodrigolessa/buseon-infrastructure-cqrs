using Buseon.Infrastructure.Abstractions;

namespace Buseon.Infrastructure.Logging;

public class MyLoggingBehavior<TRequest,TResponse>
    : IMyPipelineBehavior<TRequest,TResponse>
{
    public async Task<TResponse> HandleAsync(
        TRequest request,
        MyRequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        // TODO: Implement a better console logging with colors
        Console.WriteLine($"Handling {typeof(TRequest).Name}");

        var response = await next();

        Console.WriteLine($"Handled {typeof(TRequest).Name}");

        return response;
    }
}