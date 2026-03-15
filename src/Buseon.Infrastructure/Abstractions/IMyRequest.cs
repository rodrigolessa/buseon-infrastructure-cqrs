namespace Buseon.Infrastructure.Abstractions;

// Abstraction that could be a command, query or http request
// - for commands the response is null
public interface IMyRequest<TResponse>
{
}