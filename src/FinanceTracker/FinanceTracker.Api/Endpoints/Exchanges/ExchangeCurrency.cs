using FinanceTracker.Api.Extensions;
using FinanceTracker.Application.Exchanges.Commands.ExchangeCurrency;
using FinanceTracker.Application.Exchanges.Requests;
using MediatR;

namespace FinanceTracker.Api.Endpoints.Exchanges;

internal sealed class ExchangeCurrency : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("api/exchanges", async (ExchangeCurrencyRequest request, ISender sender)=>
            (await sender
                .Send(new ExchangeCurrencyCommand(request.Amount, request.Currency, request.Operation)))
                .Process())
            .WithTags(nameof(Exchanges));
    }
}
