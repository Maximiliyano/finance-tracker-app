using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Application.Capitals.Commands.Create;

public sealed record CreateCapitalCommand(
    string Name,
    float Balance,
    CurrencyType Currency)
    : ICommand<int>;
