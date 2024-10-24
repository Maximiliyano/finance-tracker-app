using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Application.Categories.Response;

public sealed record CategoryResponse(
    int Id,
    string Name,
    CategoryType Type,
    IEnumerable<Expense>? Expenses,
    PerPeriodType? PeriodType,
    float? PeriodAmount);
