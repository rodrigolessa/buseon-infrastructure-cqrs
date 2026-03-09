namespace Buseon.Infrastructure.Abstractions;

public interface IClock
{
    DateTime UtcNow();
}