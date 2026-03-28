using Buseon.Infrastructure.Abstractions;

namespace Buseon.Infrastructure.CQRS.Commands;

public abstract class MyCommand(
    string aggregateId,
    string? idempotencyKey,
    string? sessionKey,
    string? correlationKey,
    string? sagaProcessKey,
    string? applicationId,
    IClock clock,
    string? userEmail = null!)
    : MyBaseCommand(aggregateId, null, idempotencyKey, sessionKey, correlationKey, sagaProcessKey, applicationId, clock, userEmail);
        
// public abstract class Command(): MyBaseCommand(), MediatR.IRequest;