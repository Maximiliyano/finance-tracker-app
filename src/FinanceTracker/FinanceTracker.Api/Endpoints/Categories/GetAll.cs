using FinanceTracker.Api.Extensions;
using FinanceTracker.Application.Categories.Queries.GetAll;
using FinanceTracker.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.Api.Endpoints.Categories;

internal sealed class GetAll : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("api/categories", async (ISender sender, [FromQuery] CategoryType? type) =>
            (await sender
                .Send(new GetAllCategoryQuery(type)))
                .Process())
            .WithTags(nameof(Categories));
    }
}
