using FinanceTracker.Api.Extensions;
using FinanceTracker.Application.Expenses.Queries.GetAll;
using MediatR;

namespace FinanceTracker.Api.Endpoints.Expenses;

internal sealed class GetAll : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("api/expenses", async (int? id, ISender sender) =>
            (await sender
                .Send(new GetAllExpensesQuery(id)))
                .Process())
            .WithTags(nameof(Expenses));
    }
}
