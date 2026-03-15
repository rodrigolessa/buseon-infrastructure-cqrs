using Buseon.Infrastructure.Abstractions;
using Buseon.Infrastructure.Exceptions;
using FluentValidation;

namespace Buseon.Infrastructure.PipelineBehavior;

/// <summary>
/// It is the concept of Pipeline / Decorator applied to a Mediator.
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

    public async Task<TResponse> HandleAsync(
        TRequest request,
        MyRequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!_validators.Any())
            return await next();

        var context = new ValidationContext<TRequest>(request);

        // TODO: Replace WhenAll for best performance
        var results = await Task.WhenAll(
            _validators
                .Select(v => v.ValidateAsync(context, cancellationToken)));

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