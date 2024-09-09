using FinanceTracker.Api.Extensions;
using FinanceTracker.Application.Incomes.Queries.GetById;
using FinanceTracker.Domain.Entities;
using MediatR;

namespace FinanceTracker.Api.Endpoints.Incomes;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("api/incomes", async (int id, ISender sender) =>
            (await sender
                .Send(new GetIncomeByIdQuery(id)))
                .Process())
            .WithTags(nameof(Income));
    }
}
