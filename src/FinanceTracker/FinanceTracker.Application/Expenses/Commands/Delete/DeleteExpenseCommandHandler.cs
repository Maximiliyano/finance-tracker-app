using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Expenses.Specifications;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Expenses.Commands.Delete;

public sealed class DeleteExpenseCommandHandler(
    IExpenseRepository repository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteExpenseCommand>
{
    public async Task<Result> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
    {
        var expense = await repository.GetAsync(new ExpenseByIdSpecification(request.Id));

        if (expense is null)
        {
            return Result.Failure(DomainErrors.Expense.NotFound);
        }
        
        repository.Delete(expense);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
