using FinanceTracker.Api.Extensions;
using FinanceTracker.Application.Capitals.Commands.Create;
using FinanceTracker.Application.Capitals.Requests;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Results;
using MediatR;

namespace FinanceTracker.Api.Endpoints.Capitals;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("api/capitals", async (AddCapitalRequest request, ISender sender) =>
            (await sender
                .Send(new CreateCapitalCommand(request.Name, request.Balance)))
                .Process(ResultType.Created))
            .WithTags(nameof(Capital));
    }
}
