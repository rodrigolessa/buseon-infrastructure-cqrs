namespace Buseon.Infrastructure.Abstractions;

/// <summary>
/// Marker interface for all CQRS messages (commands, queries, events).
/// </summary>
public interface IMyMessage
{
    string MessageId { get; set; }
    string AggregateId { get; set; }
    string ApplicationId { get; set; }
    string IdempotencyKey { get; set; }
    
    string? SessionKey { get; set; }
    string? CorrelationKey { get; set; } // Previously called "RequestId" or "CommandId"
    string? SagaProcessKey { get; set; }
    
    // TODO: Avoid the primitive type and implement an E-mail struct
    string? UserEmail { get; set; }

    DateTime OccurredAt { get; set; }
}