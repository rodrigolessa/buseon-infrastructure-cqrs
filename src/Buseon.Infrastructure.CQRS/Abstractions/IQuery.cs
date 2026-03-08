namespace Buseon.Infrastructure.CQRS.Abstractions;

/// <summary>
/// Represents a query that returns data without changing system state.
/// </summary>
/// <typeparam name="TResult">The type of the result returned by the query.</typeparam>
public interface IQuery<TResult> : IMessage
{
}