using FinanceTracker.Application.Abstractions.Messaging;

namespace FinanceTracker.Application.Incomes.Commands.Update;

public sealed record UpdateIncomeCommand(
    int Id,
    int? CategoryId = null,
    float? Amount = null,
    string? Purpose = null,
    DateTimeOffset? PaymentDate = null)
    : ICommand;
