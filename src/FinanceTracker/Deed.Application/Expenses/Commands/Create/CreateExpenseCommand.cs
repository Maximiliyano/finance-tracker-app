using FinanceTracker.Application.Abstractions.Messaging;

namespace FinanceTracker.Application.Expenses.Commands.Create;

public sealed record CreateExpenseCommand(
    int CapitalId,
    int CategoryId,
    float Amount,
    DateTimeOffset PaymentDate,
    string? Purpose)
    : ICommand<int>;
