using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Capitals.Specifications;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Expenses.Commands.Create;

internal sealed class CreateExpenseCommandHandler(
    ICapitalRepository capitalRepository,
    IExpenseRepository expenseRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateExpenseCommand, int>
{
    public async Task<Result<int>> Handle(CreateExpenseCommand command, CancellationToken cancellationToken)
    {
        var capital = await capitalRepository.GetAsync(new CapitalByIdSpecification(command.CapitalId));

        if (capital is null)
        {
            return Result.Failure<int>(DomainErrors.General.NotFound);
        }

        var expense = command.ToEntity();

        capital.Balance -= expense.Amount;

        capitalRepository.Update(capital);
        
        expenseRepository.Create(expense);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(expense.Id);
    }
}
