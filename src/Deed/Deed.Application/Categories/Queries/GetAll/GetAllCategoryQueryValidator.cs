using Deed.Domain.Enums;
using FluentValidation;

namespace Deed.Application.Categories.Queries.GetAll;

internal sealed class GetAllCategoryQueryValidator : AbstractValidator<GetAllCategoryQuery>
{
    public GetAllCategoryQueryValidator()
    {
        RuleFor(q => q.Type)
            .NotEqual(CategoryType.None);
    }
}
