using FinanceTracker.Application.Abstractions.Behaviours;
using FinanceTracker.Application.Abstractions.Settings;
using FinanceTracker.Application.Exchanges;
using FinanceTracker.Application.Exchanges.Service;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceTracker.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatrDependencies();

        services.AddValidatorsFromAssembly(AssemblyReference.Assembly, includeInternalTypes: true);

        services.AddSettings();

        services.AddHttpClient<IExchangeHttpService, ExchangeHttpService>();

        return services;
    }

    private static IServiceCollection AddMediatrDependencies(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(AssemblyReference.Assembly);

            config.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));

            config.AddOpenBehavior(typeof(RequestLoggingPipelineBehavior<,>));
        });

        return services;
    }

    private static IServiceCollection AddSettings(this IServiceCollection services)
    {
        var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

        services.Configure<PBApiSettings>(configuration.GetRequiredSection(nameof(PBApiSettings)));

        services.Configure<WebUrlSettings>(configuration.GetRequiredSection(nameof(WebUrlSettings)));

        services.Configure<BackgroundJobsSettings>(configuration.GetRequiredSection(nameof(BackgroundJobsSettings)));

        return services;
    }
}
