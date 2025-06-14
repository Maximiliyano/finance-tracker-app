using Deed.Api.Extensions;
using Deed.Application.Exchanges.Queries.GetLatest;
using MediatR;

namespace Deed.Api.Endpoints.Exchanges;

internal sealed class Get : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("api/exchanges", async (ISender sender) =>
            (await sender
                .Send(new GetLatestExchangeQuery()))
                .Process())
            .WithTags(nameof(Exchanges));
    }
}
