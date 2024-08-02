using FinanceTracker.Infrastructure.Persistence.Accounts;

namespace FinanceTracker.Api.Endpoints;

internal static class CapitalsEndpoints
{
    internal static IEndpointRouteBuilder MapCapitalEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/accounts");

        group.MapGet(string.Empty, GetAll);

        return app;
    }

    private static async Task<IResult> GetAll(ICapitalRepository repository)
    {
        var result = await repository.GetAll();

        return Results.Ok(result);
    }
}