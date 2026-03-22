namespace Buseon.Infrastructure.Mediator;

public delegate Task<object?> MyRequestHandlerDelegate(
    object request,
    CancellationToken ct);