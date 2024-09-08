using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Expenses.Commands.Create;

internal sealed class CreateExpenseCommandHandler(IExpenseRepository repository, IUnitOfWork unitOfWork)
    : ICommandHandler<CreateExpenseCommand, int>
{
    public async Task<Result<int>> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
    {
        var expense = new Expense
        {
            Amount = request.Amount,
            Purpose = request.Purpose,
            Type = request.Type,
            CapitalId = request.CapitalId
        };

        repository.Create(expense);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(expense.Id);
    }
}