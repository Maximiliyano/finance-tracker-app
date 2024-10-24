using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Application.Expenses.Responses;

public sealed record ExpenseResponse(
    int Id,
    int CapitalId,
    int CategoryId,
    float Amount,
    DateTimeOffset PaymentDate,
    Category Category,
    Capital Capital,
    string? Purpose);
