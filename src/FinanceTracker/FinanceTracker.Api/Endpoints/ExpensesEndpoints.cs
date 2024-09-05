using FinanceTracker.Api.Extensions;
using FinanceTracker.Application.Expenses.Queries.GetById;
using MediatR;

namespace FinanceTracker.Api.Endpoints;

internal static class ExpensesEndpoints
{
    internal static IEndpointRouteBuilder MapExpensesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/expenses");

        group.MapGet("{id:int}", GetById);

        return group;
    }

    private static async Task<IResult> GetById(ISender sender, int id)
        => (await sender
            .Send(new GetExpenseByIdQuery(id)))
            .Process();
}