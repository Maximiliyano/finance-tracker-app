using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Expenses.Specifications;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Providers;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Expenses.Commands.Update;

public sealed class UpdateExpenseCommandHandler(
    IDateTimeProvider dateTimeProvider,
    ICapitalRepository capitalRepository,
    ICategoryRepository categoryRepository,
    IExpenseRepository expenseRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateExpenseCommand>
{
    public async Task<Result> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
    {
        var expense = await expenseRepository.GetAsync(new ExpenseByIdSpecification(request.Id));

        if (expense is null)
        {
            return Result.Failure(DomainErrors.General.NotFound);
        }

        if (request.Amount is not null)
        {
            var difference = expense.Amount - request.Amount.Value;

            expense.Capital!.Balance += difference;

            expense.Amount = request.Amount.Value;
        }
        
        expense.Purpose = request.Purpose ?? expense.Purpose;
        expense.PaymentDate = request.Date ?? dateTimeProvider.UtcNow;
        expense.CategoryId = request.CategoryId ?? expense.CategoryId;
        
        capitalRepository.Update(expense.Capital);
        categoryRepository.Update(expense.Category);
        expenseRepository.Update(expense);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success();
    }
}
