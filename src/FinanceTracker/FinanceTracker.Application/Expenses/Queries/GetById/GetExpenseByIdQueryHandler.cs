using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Expenses.Responses;
using FinanceTracker.Application.Expenses.Specifications;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Expenses.Queries.GetById;

public sealed class GetExpenseByIdQueryHandler(IExpenseRepository repository)
    : IQueryHandler<GetExpenseByIdQuery, ExpenseResponse>
{
    public async Task<Result<ExpenseResponse>> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
    {
        var expense = await repository.GetAsync(new ExpenseByIdSpecification(request.Id));

        if (expense is null)
        {
            return Result.Failure<ExpenseResponse>(DomainErrors.General.NotFound);
        }

        return expense.ToResponse();
    }
}
