using FinanceTracker.Api.Extensions;
using FinanceTracker.Application;
using FinanceTracker.Application.Capitals.Commands.Create;
using FinanceTracker.Application.Capitals.Commands.Delete;
using FinanceTracker.Application.Capitals.Commands.Update;
using FinanceTracker.Application.Capitals.Queries.GetAll;
using FinanceTracker.Application.Capitals.Queries.GetById;
using FinanceTracker.Application.Capitals.Requests;
using FinanceTracker.Domain.Results;
using MediatR;

namespace FinanceTracker.Api.Endpoints;

internal static class CapitalsEndpoints
{
    internal static IEndpointRouteBuilder MapCapitalEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/capitals");

        group.MapGet(string.Empty, GetAll);

        group.MapGet("{id:int}", GetById);

        group.MapPost(string.Empty, Create);

        group.MapPut(string.Empty, Update);

        group.MapDelete("{id:int}", Delete);

        return group;
    }

    private static async Task<IResult> GetAll(ISender sender)
        => (await sender
            .Send(new GetAllCapitalsQuery()))
            .Process();

    private static async Task<IResult> GetById(ISender sender, int id)
        => (await sender
            .Send(new GetByIdCapitalQuery(id)))
            .Process();

    private static async Task<IResult> Create(ISender sender, AddCapitalRequest request)
        => (await sender
            .Send(new CreateCapitalCommand(request.Name, request.Balance)))
            .Process(ResultType.Created);

    private static async Task<IResult> Update(ISender sender, UpdateCapitalRequest request)
        => (await sender
            .Send(new UpdateCapitalCommand(request.Id, request.Name, request.Balance)))
            .Process();

    private static async Task<IResult> Delete(ISender sender, int id)
        => (await sender
            .Send(new DeleteCapitalCommand(id)))
            .Process(ResultType.NoContent);
}