using FinanceTracker.Api.Extensions;
using FinanceTracker.Application.Categories.Commands.Create;
using FinanceTracker.Application.Categories.Requests;
using MediatR;

namespace FinanceTracker.Api.Endpoints.Categories;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("api/categories", async (CreateCategoryRequest request, ISender sender) =>
            (await sender
                .Send(new CreateCategoryCommand(
                    request.Name,
                    request.Type,
                    request.PlannedPeriodAmount,
                    request.Period)))
                .Process())
            .WithTags(nameof(Categories));
    }
}
