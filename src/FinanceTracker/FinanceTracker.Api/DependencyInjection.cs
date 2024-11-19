using FinanceTracker.Api.Infrastructure;
using FinanceTracker.Domain.Providers;

namespace FinanceTracker.Api;

internal static class DependencyInjection
{
    internal static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddHealthChecks();

        services.AddCors();

        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();

        return services;
    }
}
