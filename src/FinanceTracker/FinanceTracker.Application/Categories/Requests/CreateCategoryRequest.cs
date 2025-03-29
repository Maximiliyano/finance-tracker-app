using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Application.Categories.Requests;

public sealed record CreateCategoryRequest(
    string Name,
    CategoryType Type,
    float PlannedPeriodAmount,
    PerPeriodType Period);
