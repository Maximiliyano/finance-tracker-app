using FinanceTracker.Application.Expenses.Responses;
using FinanceTracker.Application.Incomes.Responses;
using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Application.Categories.Response;

public sealed record CategoryResponse(
    int Id,
    string Name,
    CategoryType Type,
    PerPeriodType PeriodType,
    float PeriodAmount,
    IEnumerable<ExpenseResponse> Expenses,
    IEnumerable<IncomeResponse> Incomes);
