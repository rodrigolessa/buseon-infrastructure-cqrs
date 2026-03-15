using Buseon.Infrastructure.Abstractions;
using Buseon.Infrastructure.Configurations;
using Buseon.Infrastructure.CQRS.Abstractions;

namespace Buseon.Infrastructure.CQRS.Commands;

public abstract class MyBaseCommand : IMyCommand
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
        
        MessageId = SetId(messageId);
        IdempotencyKey = SetIdempotencyKey(idempotencyKey);
        ApplicationId = SetApplicationId(applicationId);
        SetSagaProcessKey(sagaProcessKey);
    }

    private static string SetId(string? messageId)
    {
        if (string.IsNullOrWhiteSpace(messageId))
        {
            return Ulid.NewUlid().ToString();
        }
        return messageId;
    }
    
    private static string SetIdempotencyKey(string? idempotencyKey)
    {
        if (string.IsNullOrWhiteSpace(idempotencyKey))
        {
            return Ulid.NewUlid().ToString();
        }
        return idempotencyKey;
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
    
    private static string SetApplicationId(string? applicationId)
    {
        if (string.IsNullOrWhiteSpace(applicationId))
        {
            return ApplicationIdProvider.Get();
        }
        return applicationId;
    }
}