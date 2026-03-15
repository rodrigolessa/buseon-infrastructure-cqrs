using Buseon.Infrastructure.Abstractions;
using Buseon.Infrastructure.CQRS.Abstractions;

namespace Buseon.Infrastructure.CQRS.Events;

public abstract class MyBaseEvent : IMyEvent
{
    public required string MessageId { get; set; }
    public required string AggregateId { get; set; }
    public required string ApplicationId { get; set; }
    public required string IdempotencyKey { get; set; }
    public string? SessionKey { get; set; }
    public string? CorrelationKey { get; set; }
    public string? SagaProcessKey { get; set; }
    public string? UserEmail { get; set; }
    public DateTime OccurredAt { get; set; }
}