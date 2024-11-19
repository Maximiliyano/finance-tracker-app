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
            .WithError(ValidationErrors.General.AmountMustBeGreaterThanZero);

        RuleFor(i => i.PaymentDate)
            .Must(paymentDate => paymentDate != DateTime.MinValue)
            .WithError(ValidationErrors.Expense.InvalidPaymentDate);

        RuleFor(i => i.Purpose)
            .Must(purpose => purpose?.Length is not 0 && !string.IsNullOrWhiteSpace(purpose))
            .When(e => e.Purpose is not null);
    }
}
