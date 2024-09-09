using FinanceTracker.Api.Extensions;
using FinanceTracker.Application.Expenses.Queries.GetById;
using FinanceTracker.Domain.Entities;
using MediatR;

namespace FinanceTracker.Api.Endpoints.Expenses;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("api/expenses/{id:int}", async (int id, ISender sender) =>
            (await sender
                .Send(new GetExpenseByIdQuery(id)))
                .Process())
            .WithTags(nameof(Expense));
    }
}
