using FinanceTracker.Api.Extensions;
using FinanceTracker.Application.Exchanges.Queries.GetAll;
using MediatR;

namespace FinanceTracker.Api.Endpoints;

internal static class ExchangesEndpoints
{
    internal static IEndpointRouteBuilder MapExchangeEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/exchanges", GetAll);

        return app;
    }

    private static async Task<IResult> GetAll(ISender sender)
        => (await sender
            .Send(new GetAllExchangeQuery()))
            .Process();
}