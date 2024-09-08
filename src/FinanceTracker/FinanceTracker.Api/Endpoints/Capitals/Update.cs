using FinanceTracker.Api.Extensions;
using FinanceTracker.Application.Capitals.Commands.Update;
using FinanceTracker.Application.Capitals.Requests;
using MediatR;

namespace FinanceTracker.Api.Endpoints.Capitals;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("api/capitals", async (UpdateCapitalRequest request, ISender sender) =>
            (await sender
                .Send(new UpdateCapitalCommand(request.Id, request.Name, request.Balance)))
                .Process());
    }
}
