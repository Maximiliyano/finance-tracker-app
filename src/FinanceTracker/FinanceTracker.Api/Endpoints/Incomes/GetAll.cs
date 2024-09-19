using FinanceTracker.Api.Extensions;
using FinanceTracker.Application.Incomes.Queries.GetAll;
using MediatR;

namespace FinanceTracker.Api.Endpoints.Incomes;

internal sealed class GetAll : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("api/incomes", async (ISender sender) =>
            (await sender
                .Send(new GetIncomesQuery()))
                .Process())
            .WithTags(nameof(Incomes));
    }
}
