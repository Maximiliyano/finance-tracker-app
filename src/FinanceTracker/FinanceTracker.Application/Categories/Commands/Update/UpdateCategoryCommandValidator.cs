using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Constants;
using FinanceTracker.Domain.Enums;
using FinanceTracker.Domain.Errors;
using FluentValidation;

namespace FinanceTracker.Application.Categories.Commands.Update;

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
