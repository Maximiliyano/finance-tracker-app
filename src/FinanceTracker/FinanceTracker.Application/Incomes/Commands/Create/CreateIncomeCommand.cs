using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Application.Incomes.Commands.Create;

public sealed record CreateIncomeCommand(
    int CapitalId,
    float Amount,
    string Purpose,
    IncomeType Type)
    : ICommand<int>;
