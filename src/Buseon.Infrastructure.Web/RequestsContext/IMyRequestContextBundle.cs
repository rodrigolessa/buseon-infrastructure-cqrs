namespace Buseon.Infrastructure.Web.RequestsContext;

/// <summary>
/// This will be populated automatically by the pipeline
/// </summary>
public interface IMyRequestContextBundle
{
    string? ClientApplication { get; set; }
    string? IpAddress { get; set; }
    string? UserEmail { get; set; }

    // Integrated ecosystem properties
    string? IdempotencyKey { get; set; }
    string? CorrelationKey { get; set; }
    string? SagaProcessKey { get; set; }
}