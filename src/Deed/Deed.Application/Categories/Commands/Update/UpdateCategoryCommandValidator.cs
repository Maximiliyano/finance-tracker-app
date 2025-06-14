using Deed.Application.Abstractions;
using Deed.Domain.Constants;
using Deed.Domain.Enums;
using Deed.Domain.Errors;
using FluentValidation;

namespace Deed.Application.Categories.Commands.Update;

internal sealed class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(c => c.Period)
            .Must(period => period.HasValue && period.Value != PerPeriodType.None)
            .When(c => c.Period.HasValue)
            .WithError(DomainErrors.Category.InvalidPerPeriod);

        RuleFor(c => c.PlannedPeriodAmount)
            .GreaterThanOrEqualTo(ValidationConstants.ZeroValue);
    }
}
