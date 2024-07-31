using Microsoft.Extensions.Options;

namespace FinanceTracker.Api.Extensions;

internal static class WebApplicationExtensions
{
    internal static IApplicationBuilder UseSwaggerDependencies(this IApplicationBuilder builder)
        => builder
            .UseSwagger()
            .UseSwaggerUI();

    internal static IApplicationBuilder UseCorsPolicy(this IApplicationBuilder builder)
    {
        using var serviceScope = builder.ApplicationServices.CreateScope();

        var webUiSettings = serviceScope.ServiceProvider.GetRequiredService<IOptions<WebUISettings>>().Value;

        builder.UseCors(policyBuilder => policyBuilder
            .AllowCredentials()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins(webUiSettings.BaseAddress));

        return builder;
    }
}