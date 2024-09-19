using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Application.Expenses.Requests;

public sealed record UpdateExpenseRequest(
    int Id,
    float? Amount,
    string? Purpose,
    ExpenseType? Type);
