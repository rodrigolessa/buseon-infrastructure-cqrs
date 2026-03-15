using System.Diagnostics.CodeAnalysis;
using Buseon.Infrastructure.Abstractions;
using Buseon.Infrastructure.Mediator.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Buseon.Infrastructure.Mediator;

[ExcludeFromCodeCoverage]
public class MyRequestDispatcher<TRequest, TResponse>
    : IMyRequestDispatcher<TRequest, TResponse>
    where TRequest : IMyRequest<TResponse>
{
    private readonly IEnumerable<IMyPipelineBehavior<TRequest, TResponse>> _behaviors;
    private readonly IMyRequestHandler<TRequest, TResponse> _handler;

    public MyRequestDispatcher(
        IEnumerable<IMyPipelineBehavior<TRequest, TResponse>> behaviors,
        IMyRequestHandler<TRequest, TResponse> handler)
    {
        _behaviors = behaviors;
        _handler = handler;
    }

    public Task<TResponse> DispatchAsync(
        TRequest request,
        CancellationToken cancellationToken)
    {
        MyRequestHandlerDelegate<TResponse> handlerDelegate =
            () => _handler.HandleAsync(request, cancellationToken);

        foreach (var behavior in _behaviors.Reverse())
        {
            var next = handlerDelegate;

            handlerDelegate = () =>
                behavior.HandleAsync(request, next, cancellationToken);
        }

        return handlerDelegate();
    }
}

// [ExcludeFromCodeCoverage]
// public class MyRequestDispatcher(IServiceProvider serviceProvider) : IMyRequestDispatcher
// {
//     public async Task<TResponse> ProcessAsync<TRequest, TResponse>(
//         TRequest request,
//         CancellationToken cancellationToken = default)
//         where TRequest : IMyRequest<TResponse>
//     {
//         var handler = serviceProvider
//             .GetRequiredService<IMyRequestHandler<TRequest, TResponse>>();
//         
//         var behaviors = serviceProvider
//             .GetServices<IMyPipelineBehavior<TRequest, TResponse>>()
//             .Reverse()
//             .ToArray();
//
//         MyRequestHandlerDelegate<TResponse> handlerDelegate =
//             () => handler.HandleAsync(request, cancellationToken);
//         
//         foreach (var behavior in behaviors)
//         {
//             var next = handlerDelegate;
//
//             handlerDelegate = () =>
//                 behavior.Handle(request, cancellationToken, next);
//         }
//
//         return await handlerDelegate();
//         //return await handler.HandleAsync(request, cancellationToken);
//     }
// }