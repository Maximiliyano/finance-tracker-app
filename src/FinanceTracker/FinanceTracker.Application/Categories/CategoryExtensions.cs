using FinanceTracker.Application.Categories.Commands.Create;
using FinanceTracker.Application.Categories.Response;
using FinanceTracker.Application.Expenses;
using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Application.Categories;

internal static class CategoryExtensions
{
    internal static CategoryResponse ToResponse(this Category category)
        => new(
                category.Id,
                category.Name,
                category.Type,
                category.Expenses?.ToResponses(),
                category.Period, category.PlannedPeriodAmount);

    internal static IEnumerable<CategoryResponse> ToResponses(this IEnumerable<Category> categories)
        => categories.Select(e => e.ToResponse());

    internal static Category ToEntity(this CreateCategoryCommand command)
        => new()
        {
            Name = command.Name,
            Type = command.Type,
            Period = command.Period,
            PlannedPeriodAmount = command.PlannedPeriodAmount
        };
}
