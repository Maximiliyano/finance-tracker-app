using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Expenses.Responses;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Expenses.Queries.GetAll;

public sealed class GetAllExpensesQueryHandler(
    IExpenseRepository repository)
    : IQueryHandler<GetAllExpensesQuery, IEnumerable<ExpenseResponse>>
{
    public async Task<Result<IEnumerable<ExpenseResponse>>> Handle(GetAllExpensesQuery request, CancellationToken cancellationToken)
    {
        var expenses = await repository.GetAllAsync();

        var expenseResponses = expenses.Select(ex => new ExpenseResponse());

        return Result.Success(expenseResponses);
    }
}
