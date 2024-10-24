using FinanceTracker.Application.Abstractions;

namespace FinanceTracker.Application.Incomes.Commands.Create;

public sealed record CreateIncomeCommand(
    int CapitalId,
    int CategoryId,
    float Amount,
    DateTimeOffset Date,
    string? Purpose)
    : ICommand<int>;
