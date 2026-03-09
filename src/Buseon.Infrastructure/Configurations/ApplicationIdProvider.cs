namespace Buseon.Infrastructure.Configurations;

public static class ApplicationIdProvider
{
    public static string Get()
    {
        return Environment.GetEnvironmentVariable("APPLICATION_ID")
               ?? AppDomain.CurrentDomain.FriendlyName
               ?? "unknown-service";
    }
}