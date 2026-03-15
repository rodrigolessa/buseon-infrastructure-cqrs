using Buseon.Infrastructure.Abstractions;
using Buseon.Infrastructure.WebContext.Abstractions;

namespace Buseon.Infrastructure.WebContext.RequestsContext;

/// <summary>
/// Pipeline Behavior to Enrich Commands
/// </summary>
public class MyRequestContextBehavior<TRequest, TResponse>(IMyRequestContextBundle contextBundle)
    : IMyPipelineBehavior<TRequest, TResponse>
    where TRequest : class
{
    public async Task<TResponse> HandleAsync(TRequest request,
        MyRequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (request is MyBaseRequest<TResponse> baseCommand)
        {
            baseCommand.ClientApplication = contextBundle.ClientApplication;
            baseCommand.IpAddress = contextBundle.IpAddress;
            baseCommand.UserEmail = contextBundle.UserEmail;

            baseCommand.IdempotencyKey = contextBundle.IdempotencyKey;
            baseCommand.CorrelationKey = contextBundle.CorrelationKey;
            baseCommand.SagaProcessKey = contextBundle.SagaProcessKey;
        }

        return await next();
    }
}