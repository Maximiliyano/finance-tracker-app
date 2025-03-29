using FinanceTracker.Api.Extensions;
using FinanceTracker.Application.Categories.Commands.Delete;
using FinanceTracker.Domain.Results;
using MediatR;

namespace FinanceTracker.Api.Endpoints.Categories;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("api/categories/{id:int}", async (int id, ISender sender) =>
            (await sender
                .Send(new DeleteCategoryCommand(id)))
                .Process(ResultType.NoContent))
            .WithTags(nameof(Categories));
    }
}
