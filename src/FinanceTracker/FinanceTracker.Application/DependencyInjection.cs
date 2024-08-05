using FinanceTracker.Application.Exchange;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection.Metadata;

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

    private static IServiceCollection AddMediatrDependencies(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(AssemblyReference.Assembly);
        });

        return services;
    }
}