using Buseon.Infrastructure.Abstractions;
using Buseon.Infrastructure.Configurations;
using Buseon.Infrastructure.CQRS.Abstractions;

namespace Buseon.Infrastructure.CQRS.Commands;

public abstract class MyBaseCommand : ICommand
{
    public string MessageId { get; set; }
    public string AggregateId { get; set; }
    public string ApplicationId { get; set; }
    public string IdempotencyKey { get; set; }
    public string? SessionKey { get; set; }
    public string? CorrelationKey { get; set; }
    public string? SagaProcessKey { get; set; }
    public string? UserEmail { get; set; }
    public DateTime OccurredAt { get; set; }

    protected MyBaseCommand(
        string aggregateId,
        string? messageId,
        string? idempotencyKey,
        string? sessionKey,
        string? correlationKey,
        string? sagaProcessKey,
        string? applicationId,
        IClock clock,
        string? userEmail = null!)
    {
        AggregateId = aggregateId;
        SessionKey = sessionKey;
        CorrelationKey = correlationKey;
        UserEmail = userEmail;
        OccurredAt = clock.UtcNow();
        
        SetId(messageId);
        SetIdempotencyKey(idempotencyKey);
        SetSagaProcessKey(sagaProcessKey);
        SetApplicationId(applicationId);
    }

    private void SetId(string? id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            MessageId = Ulid.NewUlid().ToString();
        }
        else
        {
            MessageId = id;
        }
    }
    
    private void SetIdempotencyKey(string? idempotencyKey)
    {
        if (string.IsNullOrWhiteSpace(idempotencyKey))
        {
            IdempotencyKey = Ulid.NewUlid().ToString();
        }
        else
        {
            IdempotencyKey = idempotencyKey;
        }
    }
    
    private void SetSagaProcessKey(string? sagaProcessKey)
    {
        if (string.IsNullOrWhiteSpace(sagaProcessKey))
        {
            SagaProcessKey = Ulid.NewUlid().ToString();
        }
        else
        {
            SagaProcessKey = sagaProcessKey;
        }
    }
    
    private void SetApplicationId(string? applicationId)
    {
        if (string.IsNullOrWhiteSpace(applicationId))
        {
            ApplicationId = ApplicationIdProvider.Get();
        }
        else
        {
            ApplicationId = applicationId;
        }
    }
}