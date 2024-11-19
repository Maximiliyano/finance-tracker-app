using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Categories.Response;
using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Application.Categories.Queries.GetAll;

public sealed record GetAllCategoryQuery(
    CategoryType? Type = null)
    : IQuery<IEnumerable<CategoryResponse>>;
