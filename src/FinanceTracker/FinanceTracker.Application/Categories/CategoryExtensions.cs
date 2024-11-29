using FinanceTracker.Application.Categories.Commands.Create;
using FinanceTracker.Application.Categories.Response;
using FinanceTracker.Application.Expenses;
using FinanceTracker.Application.Incomes;
using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Application.Categories;

internal static class CategoryExtensions
{
    internal static CategoryResponse ToResponse(this Category category)
    {
        return new CategoryResponse(
                    category.Id,
                    category.Name,
                    category.Type,
                    category.Period,
                    category.PlannedPeriodAmount,
                    category.Expenses?.ToResponses() ?? [],
                    category.Incomes?.ToResponses() ?? []);
    }

    internal static IEnumerable<CategoryResponse> ToResponses(this IEnumerable<Category> categories)
    {
        return categories.Select(e => e.ToResponse());
    }

    internal static Category ToEntity(this CreateCategoryCommand command)
    {
        return new Category
        {
            Name = command.Name,
            Type = command.Type,
            Period = command.Period,
            PlannedPeriodAmount = command.PlannedPeriodAmount
        };
    }
}
