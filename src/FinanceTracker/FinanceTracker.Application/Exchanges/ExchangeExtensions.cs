using FinanceTracker.Application.Exchanges.Responses;
using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Application.Exchanges;

internal static class ExchangeExtensions
{
    internal static ExchangeResponse ToResponse(this Exchange exchange)
        => new(
            exchange.TargetCurrencyCode,
            exchange.NationalCurrencyCode,
            exchange.Buy,
            exchange.Sale,
            exchange.CreatedAt);

    internal static IEnumerable<ExchangeResponse> ToResponses(this IEnumerable<Exchange> exchanges)
        => exchanges.Select(e => e.ToResponse());

    internal static Exchange ToEntity(this ExchangeResponse response)
        => new()
        {
            NationalCurrencyCode = response.NationalCurrency,
            TargetCurrencyCode = response.TargetCurrency,
            Buy = response.Buy,
            Sale = response.Sale
        };

    internal static IEnumerable<Exchange> ToEntities(this IEnumerable<ExchangeResponse> responses)
        => responses.Select(x => x.ToEntity());
}
