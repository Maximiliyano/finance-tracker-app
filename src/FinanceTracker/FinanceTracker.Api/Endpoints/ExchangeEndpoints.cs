using FinanceTracker.Application.Exchange;

namespace FinanceTracker.Api.Endpoints;

internal static class ExchangeEndpoints
{
    internal static IEndpointRouteBuilder MapExchangeEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/exchanges", GetAll);

        return app;
    }

    private static async Task<IResult> GetAll(IExchangeHttpService service)
    {
        var result = await service.GetCurrencyAsync();

        return result.IsSuccess
            ? Results.Ok(result.Value)
            : Results.BadRequest(result.Error);
    }
}