using Deed.Api.Extensions;
using Deed.Application.Expenses.Queries.GetAll;
using MediatR;

namespace Deed.Api.Endpoints.Expenses;

internal sealed class GetAll : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("api/expenses", async (ISender sender) =>
            (await sender
                .Send(new GetAllExpensesQuery()))
                .Process())
            .WithTags(nameof(Expenses));
    }
}
