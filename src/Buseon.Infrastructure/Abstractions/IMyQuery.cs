namespace Buseon.Infrastructure.Abstractions;

/// <summary>
/// Represents a query that returns data without changing system state.
/// </summary>
/// <typeparam name="TResult">The type of the result returned by the query.</typeparam>
public interface IMyQuery<TResult> : IMyMessage
{
}