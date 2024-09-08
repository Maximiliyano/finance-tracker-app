using FinanceTracker.Api.Extensions;
using FinanceTracker.Application.Capitals.Queries.GetAll;
using MediatR;

namespace FinanceTracker.Api.Endpoints.Capitals;

internal sealed class Get : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("api/capitals", async (ISender sender) =>
            (await sender
                .Send(new GetAllCapitalsQuery()))
                .Process());
    }
}
