using FinanceTracker.Domain.Enums;
using FluentValidation;

namespace FinanceTracker.Application.Categories.Queries.GetAll;

internal sealed class GetAllCategoryQueryValidator : AbstractValidator<GetAllCategoryQuery>
{
    public GetAllCategoryQueryValidator()
    {
        RuleFor(q => q.Type)
            .NotEqual(CategoryType.None);
    }
}
