using Deed.Api.Extensions;
using Deed.Application.Capitals.Queries.GetAll;
using MediatR;

namespace Deed.Api.Endpoints.Capitals;

internal sealed class GetAll : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("api/capitals", async (ISender sender) =>
            (await sender
                .Send(new GetAllCapitalsQuery()))
                .Process())
            .WithTags(nameof(Capitals));
    }
}
