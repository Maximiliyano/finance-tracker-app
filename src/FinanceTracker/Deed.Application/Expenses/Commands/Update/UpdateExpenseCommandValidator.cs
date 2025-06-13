using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Categories.Specifications;
using FinanceTracker.Application.Expenses.Specifications;
using FinanceTracker.Domain.Enums;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Repositories;
using FluentValidation;

namespace FinanceTracker.Application.Expenses.Commands.Update;

internal sealed class UpdateExpenseCommandValidator : AbstractValidator<UpdateExpenseCommand>
{
    public UpdateExpenseCommandValidator(IExpenseRepository expenseRepository, ICategoryRepository categoryRepository)
    {
        RuleFor(e => e.CategoryId)
            .MustAsync(async (categoryId, _) => !await expenseRepository
                .AnyAsync(new ExpenseByIdSpecification(categoryId!.Value)))
            .WithError(ValidationErrors.General.NotFound("category"))
            .MustAsync(async (categoryId, _) => (await categoryRepository
                .GetAsync(new CategoryByIdSpecification(categoryId!.Value)))?.Type == CategoryType.Expenses)
            .WithError(ValidationErrors.Category.InvalidType)
            .When(e => e.CategoryId.HasValue);
    }
}
