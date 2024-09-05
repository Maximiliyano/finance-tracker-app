using FinanceTracker.Api.Extensions;
using FinanceTracker.Application.Incomes.Queries.GetById;
using MediatR;

namespace FinanceTracker.Api.Endpoints;

internal static class IncomesEndpoints
{
    internal static IEndpointRouteBuilder MapIncomesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/incomes");

        group.MapGet("{id:int}", GetByIdAsync);

        return group;
    }

    private static async Task<IResult> GetByIdAsync(ISender sender, int id)
        => (await sender
            .Send(new GetIncomeByIdQuery(id)))
            .Process();
}