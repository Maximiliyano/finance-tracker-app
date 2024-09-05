using FinanceTracker.Api.Handlers;
using FinanceTracker.Domain.Providers;

namespace FinanceTracker.Api;

internal static class DependencyInjection
{
    internal static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddHealthChecks();

        services.AddCors();

        services.AddProblemDetails();

        services.AddExceptionHandler<GlobalExceptionHandler>();

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();

        return services;
    }
}