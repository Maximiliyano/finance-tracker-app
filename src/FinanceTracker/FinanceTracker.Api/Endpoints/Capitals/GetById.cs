using FinanceTracker.Api.Extensions;
using FinanceTracker.Application.Capitals.Queries.GetById;
using FinanceTracker.Domain.Entities;
using MediatR;

namespace FinanceTracker.Api.Endpoints.Capitals;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("api/capitals/{id:int}", async (int id, ISender sender) => 
            (await sender
                .Send(new GetByIdCapitalQuery(id)))
                .Process())
            .WithTags(nameof(Capital));
    }
}
