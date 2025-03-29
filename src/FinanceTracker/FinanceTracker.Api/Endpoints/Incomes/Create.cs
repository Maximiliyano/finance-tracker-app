using FinanceTracker.Api.Extensions;
using FinanceTracker.Application.Incomes.Commands.Create;
using FinanceTracker.Application.Incomes.Requests;
using MediatR;

namespace FinanceTracker.Api.Endpoints.Incomes;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("api/incomes", async (CreateIncomeRequest request, ISender sender) =>
            (await sender
                .Send(new CreateIncomeCommand(
                    request.CapitalId,
                    request.CategoryId,
                    request.Amount,
                    request.PaymentDate,
                    request.Purpose)))
                .Process())
            .WithTags(nameof(Incomes));
    }
}
