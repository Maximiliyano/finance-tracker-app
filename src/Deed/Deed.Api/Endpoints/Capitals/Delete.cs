using Deed.Domain.Results;
using Deed.Api.Extensions;
using Deed.Application.Capitals.Commands.Delete;
using MediatR;

namespace Deed.Api.Endpoints.Capitals;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("api/capitals/{id:int}", async (int id, ISender sender) =>
            (await sender
                .Send(new DeleteCapitalCommand(id)))
                .Process(ResultType.NoContent))
            .WithTags(nameof(Capitals));
    }
}
