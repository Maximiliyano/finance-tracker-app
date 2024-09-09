using FinanceTracker.Api.Extensions;
using FinanceTracker.Application.Exchanges.Queries.GetAll;
using FinanceTracker.Domain.Entities;
using MediatR;

namespace FinanceTracker.Api.Endpoints.Exchanges;

internal sealed class Get : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app) // TODO add own exchange table and save latest currency
    {
        app.MapGet("api/exchanges", async (ISender sender) =>
            (await sender
                .Send(new GetAllExchangeQuery()))
                .Process())
            .WithTags(nameof(Exchange));
    }
}
