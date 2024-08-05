using FinanceTracker.Application.Requests;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Infrastructure.Persistence.Abstractions;
using FinanceTracker.Infrastructure.Persistence.Accounts;

namespace FinanceTracker.Api.Endpoints;

internal static class CapitalsEndpoints
{
    internal static IEndpointRouteBuilder MapCapitalEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/capitals");

        group.MapGet(string.Empty, GetAll);

        group.MapPost(string.Empty, Create);

        return app;
    }

    private static async Task<IResult> GetAll(ICapitalRepository repository)
    {
        var capitals = await repository.GetAllAsync();

        return Results.Ok(capitals);
    }

    private static async Task<IResult> Create(
        CreateCapitalRequest request,
        ICapitalRepository repository,
        IUnitOfWork unitOfWork,
        CancellationToken cancellationToken)
    {
        var capital = new Capital()
        {
            Name = request.Name,
            TotalExpense = 0,
            TotalIncome = 0,
            TotalTransferIn = 0,
            TotalTransferOut = 0,
        };

        repository.Create(capital);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Results.Created();
    }
}