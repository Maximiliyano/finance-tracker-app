using FinanceTracker.Infrastructure.Persistence.Accounts;

namespace FinanceTracker.Api.Endpoints;

internal static class AccountEndpoints
{
    internal static IEndpointRouteBuilder MapAccountEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/accounts");

        group.MapGet(string.Empty, GetAll);

        return app;
    }

    private static async Task<IResult> GetAll(IAccountRepository repository)
    {
        var result = await repository.GetAll();

        return Results.Ok(result);
    }
}