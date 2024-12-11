using FinanceTracker.Application.Abstractions.Messaging;

namespace FinanceTracker.Application.Incomes.Commands.Create;

public sealed record CreateIncomeCommand(
    int CapitalId,
    int CategoryId,
    float Amount,
    DateTimeOffset PaymentDate,
    string? Purpose = null)
    : ICommand<int>;
