using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Expenses.Specifications;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Repositories;
using FluentValidation;

namespace FinanceTracker.Application.Expenses.Commands.Update;

internal sealed class UpdateExpenseCommandValidator : AbstractValidator<UpdateExpenseCommand>
{
    public UpdateExpenseCommandValidator(IExpenseRepository repository)
    {
        RuleFor(e => e.CategoryId)
            .MustAsync(async (categoryId, _) => !await repository
                .AnyAsync(new ExpenseByIdSpecification(categoryId!.Value)))
            .When(e => e.CategoryId.HasValue)
            .WithError(ValidationErrors.General.NotFound("category"));
    }
}
