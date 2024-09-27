using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Constants;
using FinanceTracker.Domain.Errors;
using FluentValidation;

namespace FinanceTracker.Application.Expenses.Commands.Create;

internal sealed class CreateExpenseCommandValidator : AbstractValidator<CreateExpenseCommand>
{
    public CreateExpenseCommandValidator()
    {
        RuleFor(i => i.Amount)
            .GreaterThanOrEqualTo(ValidationConstants.ZeroValue)
            .WithError(ValidationErrors.Amount.AmountMustBeGreaterThanZero);

        RuleFor(i => i.Purpose)
            .NotEmpty();
    }
}
