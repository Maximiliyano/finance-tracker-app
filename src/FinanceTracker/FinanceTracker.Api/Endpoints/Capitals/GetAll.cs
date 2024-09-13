using FinanceTracker.Api.Extensions;
using FinanceTracker.Application.Capitals.Queries.GetAll;
using FinanceTracker.Domain.Entities;
using MediatR;

namespace FinanceTracker.Api.Endpoints.Capitals;

internal sealed class GetAll : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("api/capitals", async (ISender sender) =>
            (await sender
                .Send(new GetAllCapitalsQuery()))
                .Process())
            .WithTags(nameof(Capital));
    }
}
