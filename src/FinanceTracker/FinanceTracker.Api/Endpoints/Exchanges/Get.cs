using FinanceTracker.Api.Extensions;
using FinanceTracker.Application.Exchanges.Queries.GetAll;
using FinanceTracker.Application.Exchanges.Queries.GetLatest;
using FinanceTracker.Domain.Entities;
using MediatR;

namespace FinanceTracker.Api.Endpoints.Exchanges;

internal sealed class Get : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("api/exchanges", async (ISender sender) =>
            (await sender
                .Send(new GetLatestExchangeQuery()))
                .Process())
            .WithTags(nameof(Exchange));
    }
}
