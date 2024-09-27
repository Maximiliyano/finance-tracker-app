using FinanceTracker.Api.Extensions;
using FinanceTracker.Application.Incomes.Queries.GetById;
using MediatR;

namespace FinanceTracker.Api.Endpoints.Incomes;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("api/incomes/{id:int}", async (int id, ISender sender) =>
            (await sender
                .Send(new GetIncomeByIdQuery(id)))
                .Process())
            .WithTags(nameof(Incomes));
    }
}
