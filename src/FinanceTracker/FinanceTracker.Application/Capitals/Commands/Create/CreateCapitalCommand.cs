using FinanceTracker.Application.Abstractions.Messaging;
using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Application.Capitals.Commands.Create;

public sealed record CreateCapitalCommand(
    string Name,
    float Balance,
    CurrencyType Currency)
    : ICommand<int>;
