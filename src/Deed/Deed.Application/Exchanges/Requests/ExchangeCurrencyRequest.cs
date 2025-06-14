using Deed.Domain.Enums;

namespace Deed.Application.Exchanges.Requests;

public sealed record ExchangeCurrencyRequest(
    float Amount,
    CurrencyType Currency,
    ExchangeOperationType Operation);
