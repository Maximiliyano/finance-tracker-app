using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Expenses.Responses;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Expenses.Queries.GetAll;

internal sealed class GetAllExpensesQueryHandler(
    IExpenseRepository repository)
    : IQueryHandler<GetAllExpensesQuery, IEnumerable<ExpenseResponse>>
{
    public async Task<Result<IEnumerable<ExpenseResponse>>> Handle(GetAllExpensesQuery query, CancellationToken cancellationToken)
    {
        var expenses = await repository.GetAllAsync();

        var responses = expenses.ToResponses();

        return Result.Success(responses);
    }
}
