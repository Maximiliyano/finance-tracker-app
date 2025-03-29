using FinanceTracker.Api.Extensions;
using FinanceTracker.Application.Incomes.Commands.Update;
using FinanceTracker.Application.Incomes.Requests;
using MediatR;

namespace FinanceTracker.Api.Endpoints.Incomes;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("api/incomes", async (UpdateIncomeRequest request, ISender sender) =>
            (await sender
                .Send(new UpdateIncomeCommand(
                    request.Id,
                    request.CategoryId,
                    request.Amount,
                    request.Purpose,
                    request.PaymentDate)))
                .Process())
            .WithTags(nameof(Incomes));
    }
}
