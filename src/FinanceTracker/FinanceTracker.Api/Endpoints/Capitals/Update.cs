using FinanceTracker.Api.Extensions;
using FinanceTracker.Application.Capitals.Commands.Update;
using FinanceTracker.Application.Capitals.Requests;
using MediatR;

namespace FinanceTracker.Api.Endpoints.Capitals;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("api/capitals/{id:int}", async (int id, UpdateCapitalRequest request, ISender sender) =>
            (await sender
                .Send(new UpdateCapitalCommand(id, request.Name, request.Balance, request.Currency)))
                .Process())
            .WithTags(nameof(Capitals));
    }
}
