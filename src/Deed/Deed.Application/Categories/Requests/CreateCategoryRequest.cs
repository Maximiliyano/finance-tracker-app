using Deed.Domain.Enums;

namespace Deed.Application.Categories.Requests;

public sealed record CreateCategoryRequest(
    string Name,
    CategoryType Type,
    float PlannedPeriodAmount,
    PerPeriodType Period);
