using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Application.Incomes.Commands.Update;

public sealed record UpdateIncomeCommand(
    int Id,
    float Amount,
    string Purpose,
    IncomeType Type)
    : ICommand;
