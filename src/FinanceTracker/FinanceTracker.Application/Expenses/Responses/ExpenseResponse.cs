using FinanceTracker.Application.Capitals.Responses;
using FinanceTracker.Application.Categories.Response;

namespace FinanceTracker.Application.Expenses.Responses;

public sealed record ExpenseResponse(
    int Id,
    int CapitalId,
    CapitalResponse Capital,
    int CategoryId,
    CategoryResponse Category,
    float Amount,
    DateTimeOffset PaymentDate,
    string? Purpose);
