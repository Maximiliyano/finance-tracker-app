using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Application.Expenses.Responses;

public sealed record ExpenseResponse(
    int CapitalId,
    float Amount,
    string? Purpose,
    ExpenseType Type);
