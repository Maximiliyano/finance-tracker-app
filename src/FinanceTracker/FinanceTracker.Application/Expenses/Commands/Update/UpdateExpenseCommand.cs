using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Application.Expenses.Commands.Update;

public sealed record UpdateExpenseCommand(
    int Id,
    float? Amount,
    string? Purpose,
    ExpenseType? ExpenseType)
    : ICommand;
