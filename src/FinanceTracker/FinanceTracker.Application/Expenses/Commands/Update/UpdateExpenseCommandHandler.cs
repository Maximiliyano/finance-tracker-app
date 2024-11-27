using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Expenses.Specifications;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Providers;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Expenses.Commands.Update;

internal sealed class UpdateExpenseCommandHandler(
    IDateTimeProvider dateTimeProvider,
    ICapitalRepository capitalRepository,
    ICategoryRepository categoryRepository,
    IExpenseRepository expenseRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateExpenseCommand>
{
    public async Task<Result> Handle(UpdateExpenseCommand command, CancellationToken cancellationToken)
    {
        var expense = await expenseRepository.GetAsync(new ExpenseByIdSpecification(command.Id));

        if (expense is null)
        {
            return Result.Failure(DomainErrors.General.NotFound(nameof(expense)));
        }

        if (command.Amount is not null)
        {
            var difference = expense.Amount - command.Amount.Value;

            expense.Capital!.Balance += difference;

            expense.Amount = command.Amount.Value;
        }

        expense.Purpose = command.Purpose ?? expense.Purpose;
        expense.PaymentDate = command.Date ?? dateTimeProvider.UtcNow;
        expense.CategoryId = command.CategoryId ?? expense.CategoryId;

        capitalRepository.Update(expense.Capital!);
        categoryRepository.Update(expense.Category!);
        expenseRepository.Update(expense);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
