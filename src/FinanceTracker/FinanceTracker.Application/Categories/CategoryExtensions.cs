using FinanceTracker.Application.Categories.Response;
using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Application.Categories;

internal static class CategoryExtensions
{
    internal static CategoryResponse ToResponse(this Category category)
        => new(
                category.Id,
                category.Name,
                category.Type,
                category.Expenses,
                category.Period, category.PlannedPeriodAmount);

    internal static IEnumerable<CategoryResponse> ToResponses(this IEnumerable<Category> categories)
        => categories.Select(e => e.ToResponse());
}
