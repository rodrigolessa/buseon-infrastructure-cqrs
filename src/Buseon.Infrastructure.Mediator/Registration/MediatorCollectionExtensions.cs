using Buseon.Infrastructure.Mediator.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Buseon.Infrastructure.Mediator.Registration;

public static class MediatorCollectionExtensions
{
    public static void UseMyMediator(this IServiceCollection services)
    {
        services.AddScoped(typeof(IMyRequestDispatcher<,>), typeof(MyRequestDispatcher<,>));

        //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
    }
}