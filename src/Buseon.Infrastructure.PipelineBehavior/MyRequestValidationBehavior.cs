using Buseon.Infrastructure.CQRS.Abstractions;
using Buseon.Infrastructure.Exceptions;
using Buseon.Infrastructure.PipelineBehavior.Abstractions;
using FluentValidation;

namespace Buseon.Infrastructure.PipelineBehavior;

/// <summary>
/// O conceito é Pipeline / Decorator aplicado ao Mediator.
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public sealed class MyRequestValidationBehavior<TRequest, TResponse>
    : IMyPipelineBehavior<TRequest, TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public MyRequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        if (!_validators.Any())
            return await next();

        var context = new ValidationContext<TRequest>(request);

        // TODO: Replace WhenAll for another with a best performance
        var results = await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var failures = results
            .SelectMany(r => r.Errors)
            .Where(f => f != null)
            .ToList();

        if (failures.Count > 0)
        {
            throw request switch
            {
                IMyCommand => new FrustratedCommandExecutionException(failures),
                IMyQuery<TResponse> => new FrustratedQueryExecutionException(failures),
                _ => new ValidationException(failures)
            };
        }

        return await next();
    }
}