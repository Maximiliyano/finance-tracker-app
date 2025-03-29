using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Categories.Specifications;
using FinanceTracker.Domain.Constants;
using FinanceTracker.Domain.Enums;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Repositories;
using FluentValidation;

namespace FinanceTracker.Application.Expenses.Commands.Create;

internal sealed class CreateExpenseCommandValidator : AbstractValidator<CreateExpenseCommand>
{
    public CreateExpenseCommandValidator(ICategoryRepository categoryRepository)
    {
        RuleFor(e => e.CategoryId)
            .MustAsync(async (categoryId, _) => await categoryRepository
                .AnyAsync(new CategoryByIdSpecification(categoryId)))
            .WithError(ValidationErrors.General.NotFound("category"))
            .MustAsync(async (categoryId, _) => (await categoryRepository
                .GetAsync(new CategoryByIdSpecification(categoryId)))?.Type == CategoryType.Expenses)
            .WithError(ValidationErrors.Category.InvalidType);

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
