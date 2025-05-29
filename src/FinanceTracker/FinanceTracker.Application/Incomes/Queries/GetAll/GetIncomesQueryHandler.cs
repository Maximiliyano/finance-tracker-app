using FinanceTracker.Application.Abstractions.Messaging;
using FinanceTracker.Application.Incomes.Responses;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Incomes.Queries.GetAll;

internal sealed class GetIncomesQueryHandler(
    IIncomeRepository repository)
    : IQueryHandler<GetIncomesQuery, IEnumerable<IncomeResponse>>
{
    public async Task<Result<IEnumerable<IncomeResponse>>> Handle(GetIncomesQuery query, CancellationToken cancellationToken)
    {
        var incomes = await repository.GetAllAsync();

        var incomeResponses = incomes.ToResponses();

        return Result.Success(incomeResponses);
    }
}
