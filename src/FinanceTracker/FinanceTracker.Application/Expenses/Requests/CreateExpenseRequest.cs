using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Application.Expenses.Requests;

public sealed record CreateExpenseRequest(
    int CapitalId,
    float Amount,
    string Purpose,
    ExpenseType Type);
