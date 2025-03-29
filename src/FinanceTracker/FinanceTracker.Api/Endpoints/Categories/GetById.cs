using FinanceTracker.Api.Extensions;
using FinanceTracker.Application.Categories.Queries.GetById;
using MediatR;

namespace FinanceTracker.Api.Endpoints.Categories;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("api/categories/{id:int}", async (int id, ISender sender) =>
            (await sender
                .Send(new GetByIdCategoryQuery(id)))
                .Process())
            .WithTags(nameof(Categories));
    }
}
