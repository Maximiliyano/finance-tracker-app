using FinanceTracker.Application.Abstractions.Messaging;
using FinanceTracker.Application.Expenses.Responses;
using FinanceTracker.Application.Expenses.Specifications;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Expenses.Queries.GetById;

internal sealed class GetExpenseByIdQueryHandler(IExpenseRepository repository)
    : IQueryHandler<GetExpenseByIdQuery, ExpenseResponse>
{
    public async Task<Result<ExpenseResponse>> Handle(GetExpenseByIdQuery query, CancellationToken cancellationToken)
    {
        var expense = await repository.GetAsync(new ExpenseByIdSpecification(query.Id));

        if (expense is null)
        {
            return Result.Failure<ExpenseResponse>(DomainErrors.General.NotFound(nameof(expense)));
        }

        return expense.ToResponse();
    }
}
