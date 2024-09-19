using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Application.Exchanges.Commands.ExchangeCurrency;

public sealed record ExchangeCurrencyCommand(
    float Amount,
    CurrencyType Currency,
    ExchangeOperationType Operation)
    : ICommand<float>;
