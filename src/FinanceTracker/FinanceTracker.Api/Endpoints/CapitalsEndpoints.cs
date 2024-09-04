using FinanceTracker.Api.Extensions;
using FinanceTracker.Application.Capitals.Commands.Add;
using FinanceTracker.Application.Capitals.Queries.GetAll;
using FinanceTracker.Application.Capitals.Queries.GetById;
using FinanceTracker.Application.Capitals.Requests;
using MediatR;

namespace FinanceTracker.Api.Endpoints;

internal static class CapitalsEndpoints
{
    internal static IEndpointRouteBuilder MapCapitalEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/capitals");

        group.MapGet(string.Empty, GetAll);

        group.MapGet("{id:int}", GetById);

        group.MapPost(string.Empty, Add);

        return app;
    }

    private static async Task<IResult> GetAll(ISender sender)
        => (await sender
            .Send(new GetAllCapitalsQuery()))
            .Process();

    private static async Task<IResult> GetById(ISender sender, int id)
        => (await sender
            .Send(new GetByIdCapitalQuery(id)))
            .Process();

    private static async Task<IResult> Add(ISender sender, AddCapitalRequest request)
        => (await sender
            .Send(new AddCapitalCommand(request.Name, request.Balance)))
            .Process();
}