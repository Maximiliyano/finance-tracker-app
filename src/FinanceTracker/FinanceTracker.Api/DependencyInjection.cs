using FinanceTracker.Api.Handlers;
using FinanceTracker.Application.Exchange;

namespace FinanceTracker.Api;

internal static class DependencyInjection
{
    internal static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddHealthChecks();

        services.AddCors();

        services.AddProblemDetails();

        services.AddExceptionHandler<GlobalExceptionHandler>();

        services.AddHttpClient<IExchangeHttpService, ExchangeHttpService>();

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();

        return services;
    }
}