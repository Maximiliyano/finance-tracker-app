using FinanceTracker.Api.Extensions;
using FinanceTracker.Application.Exchanges.Queries.GetAll;
using MediatR;

namespace FinanceTracker.Api.Endpoints.Exchanges;

internal sealed class Get : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("api/exchanges", async (ISender sender) =>
            (await sender
                .Send(new GetAllExchangeQuery()))
                .Process());
    }
}
