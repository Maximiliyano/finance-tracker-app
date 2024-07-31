using FinanceTracker.Api;
using FinanceTracker.Application.Exchange;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceTracker.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

        services.Configure<PBApiSettings>(configuration.GetRequiredSection(nameof(PBApiSettings)));

        services.Configure<WebUISettings>(configuration.GetRequiredSection(nameof(WebUISettings)));

        return services;
    }
}