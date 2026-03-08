namespace Buseon.Infrastructure.CQRS.Abstractions;

public interface IClock
{
    DateTime UtcNow();
}