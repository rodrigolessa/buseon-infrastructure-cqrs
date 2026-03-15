using Buseon.Infrastructure.Abstractions;
using Buseon.Infrastructure.WebContext.Abstractions;
using Buseon.Infrastructure.WebContext.RequestsContext;
using Microsoft.Extensions.DependencyInjection;

namespace Buseon.Infrastructure.WebContext.Registration;

public static class RequestContextCollectionExtensions
{
    public static void EnrichRequestContext(this IServiceCollection services)
    {
        // Now any part of the application can use it, and it is instantiated on every request.
        services.AddScoped<MyRequestContextBundle>();
        services.AddScoped<IMyRequestContextBundle>(sp => sp.GetRequiredService<MyRequestContextBundle>());
        
        services.AddScoped(typeof(IMyPipelineBehavior<,>), typeof(MyRequestContextBehavior<,>));
    }
}