using FinanceTracker.Api.Extensions;
using FinanceTracker.Application.Incomes.Commands.Delete;
using MediatR;

namespace FinanceTracker.Api.Endpoints.Incomes;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("api/incomes/{id:int}", async (int id, ISender sender) =>
            (await sender
                .Send(new DeleteIncomeCommand(id)))
                .Process())
            .WithTags(nameof(Incomes));
    }
}
