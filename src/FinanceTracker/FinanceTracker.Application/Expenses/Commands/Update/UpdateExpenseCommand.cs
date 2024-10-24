using FinanceTracker.Application.Abstractions;

namespace FinanceTracker.Application.Expenses.Commands.Update;

public sealed record UpdateExpenseCommand(
    int Id,
    int? CategoryId,
    float? Amount,
    string? Purpose,
    DateTimeOffset? Date)
    : ICommand;
