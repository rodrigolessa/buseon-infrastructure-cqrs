namespace Buseon.Infrastructure.Abstractions;

public abstract class MyBaseRequest<TResponse> : IMyRequest<TResponse>
{
    public string? ClientApplication { get; set; }
    public string? IpAddress { get; set; }
    public string? UserEmail { get; set; }
    public string? IdempotencyKey { get; set; }
    public string? CorrelationKey { get; set; }
    public string? SagaProcessKey { get; set; }
}