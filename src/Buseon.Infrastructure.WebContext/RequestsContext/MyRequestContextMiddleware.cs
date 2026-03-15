using Microsoft.AspNetCore.Http;

namespace Buseon.Infrastructure.WebContext.RequestsContext;

public class MyRequestContextMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context, MyRequestContextBundle requestContext)
    {
        // Capture custom header (e.g., X-Client-Application)
        requestContext.ClientApplication = context.Request.Headers["X-Client-Application"].FirstOrDefault();

        // Capture IP address
        requestContext.IpAddress = context.Connection.RemoteIpAddress?.ToString();
        
        if (string.IsNullOrEmpty(requestContext.ClientApplication))
        {
            // Capture User-Agent (useful for identifying Postman)
            // Optionally allow local debugging or Postman
            var userAgent = context.Request.Headers["User-Agent"].FirstOrDefault();
            if (userAgent?.Contains("Postman", StringComparison.OrdinalIgnoreCase) == true)
            {
                requestContext.ClientApplication = "GuidedOperation";
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Missing X-Client-Application header");
                return;
            }
        }
        
        requestContext.IdempotencyKey = context.Request.Headers["X-Idempotency-Key"].FirstOrDefault();
        requestContext.CorrelationKey = context.Request.Headers["X-Correlation-Key"].FirstOrDefault();
        requestContext.SagaProcessKey = context.Request.Headers["X-Saga-Process-Key"].FirstOrDefault();

        await next(context); // Must call this to continue the pipeline
    }    
}