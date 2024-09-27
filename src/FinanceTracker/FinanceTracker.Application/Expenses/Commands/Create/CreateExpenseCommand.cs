using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Application.Expenses.Commands.Create;

public sealed record CreateExpenseCommand(
    int CapitalId,
    float Amount,
    string Purpose,
    ExpenseType Type)
    : ICommand<int>;