using FinanceTracker.Application.Abstractions.Messaging;

namespace FinanceTracker.Application.Expenses.Commands.Update;

public sealed record UpdateExpenseCommand(
    int Id,
    int? CategoryId = null,
    float? Amount = null,
    string? Purpose = null,
    DateTimeOffset? Date = null)
    : ICommand;
