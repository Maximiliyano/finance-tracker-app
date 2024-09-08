using FinanceTracker.Api.Extensions;
using FinanceTracker.Application.Capitals.Commands.Delete;
using FinanceTracker.Domain.Results;
using MediatR;

namespace FinanceTracker.Api.Endpoints.Capitals;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("api/capitals/{id:int}", async (int id, ISender sender) =>
            (await sender
                .Send(new DeleteCapitalCommand(id)))
                .Process(ResultType.NoContent));
    }
}
