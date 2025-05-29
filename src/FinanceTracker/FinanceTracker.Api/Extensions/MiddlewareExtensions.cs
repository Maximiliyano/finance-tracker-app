using FinanceTracker.Api.Middlewares;

namespace FinanceTracker.Api.Extensions;

internal static class MiddlewareExtensions
{
    internal static IApplicationBuilder UseRequestContextLogging(this IApplicationBuilder app)
    {
        app.UseMiddleware<RequestContextLoggingMiddleware>();

        return app;
    }
}
