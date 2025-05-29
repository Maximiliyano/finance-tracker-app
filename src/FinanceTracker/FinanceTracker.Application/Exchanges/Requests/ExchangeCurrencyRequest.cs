using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Application.Exchanges.Requests;

public sealed record ExchangeCurrencyRequest(
    float Amount,
    CurrencyType Currency,
    ExchangeOperationType Operation);
