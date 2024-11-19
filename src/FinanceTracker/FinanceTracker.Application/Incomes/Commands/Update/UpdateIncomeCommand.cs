using FinanceTracker.Application.Abstractions;

namespace FinanceTracker.Application.Incomes.Commands.Update;

public sealed record UpdateIncomeCommand(
    int Id,
    int? CategoryId,
    float? Amount,
    string? Purpose,
    DateTimeOffset? PaymentDate,
    DateTimeOffset? Date)
    : ICommand;
