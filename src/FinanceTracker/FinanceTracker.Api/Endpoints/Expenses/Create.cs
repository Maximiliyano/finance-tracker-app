using FinanceTracker.Api.Extensions;
using FinanceTracker.Application.Expenses.Commands.Create;
using FinanceTracker.Application.Expenses.Requests;
using MediatR;

namespace FinanceTracker.Api.Endpoints.Expenses;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("api/expenses", async (CreateExpenseRequest request, ISender sender) =>
            (await sender
                .Send(new CreateExpenseCommand(request.CapitalId, request.Amount, request.Purpose, request.Type)))
                .Process())
            .WithTags(nameof(Expenses));
    }
}
