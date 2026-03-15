using Buseon.Infrastructure.WebContext.Abstractions;

namespace Buseon.Infrastructure.WebContext.RequestsContext;

public class MyRequestContextBundle: IMyRequestContextBundle
{
    public string? ClientApplication { get; set; }
    public string? IpAddress { get; set; }

    public string? UserEmail { get; set; }

    public string? IdempotencyKey { get; set; }
    public string? CorrelationKey { get; set; }
    public string? SagaProcessKey { get; set; }
}