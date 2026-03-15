# My Mediator

My own mediator implementation separates the public API from the internal execution pipeline:
It is good for:
- high performance
- clean pipeline behaviors
- minimal reflection
- good DI resolution

## Public API (simple for the user)

```
public interface IMediator
{
    Task<TResponse> SendAsync<TResponse>(
        IMyRequest<TResponse> request,
        CancellationToken cancellationToken = default);
}
```

- Only TResponse is generic
- Request is typed as IMyRequest<TResponse>
- The concrete request type is lost at compile-time
- But is nice and clean

## Internal execution contract
Inside the mediator implementation you use a fully typed execution pipeline.

```
public interface IRequestExecutor<TRequest, TResponse>
    where TRequest : IMyRequest<TResponse>
{
    Task<TResponse> Execute(
        TRequest request,
        CancellationToken cancellationToken);
}
```

- Stronger typing (more type-safe)
- Easier DI resolution
- Avoids runtime reflection
- Works better with pipeline behaviors