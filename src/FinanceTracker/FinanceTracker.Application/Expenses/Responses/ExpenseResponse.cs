using FinanceTracker.Application.Categories.Response;

namespace FinanceTracker.Application.Expenses.Responses;

public sealed record ExpenseResponse(
    int Id,
    int CapitalId,
    CategoryResponse Category,
    float Amount,
    DateTimeOffset PaymentDate,
    string? Purpose);
