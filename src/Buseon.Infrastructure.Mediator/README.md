# My Mediator

My own Mediator with compiler handler implementation. Its separates the public API from the internal execution pipeline:
It is good for:
- high performance
- clean pipeline behaviors
- no reflection, but complex DI resolution
  - Discover handlers at startup
  - Build compiled delegates
  - Store them in a dispatch table
  - Execute them with O(1) lookup

---

The key idea is:

> Build the **entire execution pipeline at startup** and execute **compiled delegates** at runtime.

This eliminates:

- `IServiceProvider`
- reflection
- runtime handler resolution

The runtime cost becomes **just a dictionary lookup + delegate invocation**.

---

## Public API (simple for the user)

```
public interface IRequest<TResponse> { }

public interface IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    Task<TResponse> HandleAsync(
        TRequest request,
        CancellationToken cancellationToken);
}
```
---

## Dispatch Table

The mediator will store compiled delegates.

```
public delegate Task<object?> RequestHandlerDelegate(
    object request,
    CancellationToken ct);

public sealed class HandlerRegistry
{
    private readonly Dictionary<Type, RequestHandlerDelegate> _handlers = new();
}
```
---

## Compiling Handler Delegates

We compile invocation logic once at startup.

---

## Adding Pipeline Behaviors

You wrap the delegate:

```
RequestHandlerDelegate pipeline =
    validation(
        logging(
            metrics(
                handler)));
```