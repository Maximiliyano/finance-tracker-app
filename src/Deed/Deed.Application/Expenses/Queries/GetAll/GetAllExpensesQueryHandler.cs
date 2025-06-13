using Deed.Application.Abstractions.Messaging;
using Deed.Application.Expenses.Responses;
using Deed.Domain.Repositories;
using Deed.Domain.Results;

namespace Deed.Application.Expenses.Queries.GetAll;

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
