using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Categories.Specifications;
using FinanceTracker.Domain.Constants;
using FinanceTracker.Domain.Enums;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Repositories;
using FluentValidation;

namespace FinanceTracker.Application.Categories.Commands.Create;

internal sealed class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator(ICategoryRepository repository)
    {
        RuleFor(c => c.Name)
            .MustAsync(async (name, _) => !await repository
                .AnyAsync(new CategoryByNameSpecification(name)))
            .WithError(ValidationErrors.Category.AlreadyExists)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MaxLenghtName);

        RuleFor(c => c.Type)
            .Must(type => type is not CategoryType.None)
            .WithError(ValidationErrors.Category.InvalidType);

        RuleFor(c => c.PlannedPeriodAmount)
            .GreaterThanOrEqualTo(ValidationConstants.ZeroValue);
    }
};
