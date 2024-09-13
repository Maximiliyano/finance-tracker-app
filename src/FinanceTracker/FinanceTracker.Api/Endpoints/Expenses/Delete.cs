using FinanceTracker.Api.Extensions;
using FinanceTracker.Application.Expenses.Commands.Delete;
using FinanceTracker.Domain.Results;
using MediatR;

namespace FinanceTracker.Api.Endpoints.Expenses;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("api/expenses/{id:int}", async (int id, ISender sender) => 
            (await sender
                .Send(new DeleteExpenseCommand(id)))
                .Process(ResultType.NoContent));
    }
}
