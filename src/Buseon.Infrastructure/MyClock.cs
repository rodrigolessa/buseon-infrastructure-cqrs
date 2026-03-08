using Buseon.Infrastructure.Abstractions;

namespace Buseon.Infrastructure;

public sealed class MyClock: IClock
{
    public DateTime UtcNow() => DateTime.UtcNow;
}