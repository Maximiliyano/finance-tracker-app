using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Capitals.Specifications;
using FinanceTracker.Domain.Constants;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Repositories;
using FluentValidation;

namespace FinanceTracker.Application.Incomes.Commands.Create;

internal sealed class CreateIncomeCommandValidator : AbstractValidator<CreateIncomeCommand>
{
    public CreateIncomeCommandValidator()
    {
        RuleFor(i => i.Amount)
            .GreaterThanOrEqualTo(ValidationConstants.ZeroValue)
            .WithError(ValidationErrors.Amount.AmountMustBeGreaterThanZero);

        RuleFor(i => i.Purpose)
            .NotEmpty();
    }
}
