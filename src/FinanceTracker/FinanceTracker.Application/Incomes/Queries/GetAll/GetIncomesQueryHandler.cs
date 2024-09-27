using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Incomes.Responses;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Incomes.Queries.GetAll;

public sealed class GetIncomesQueryHandler(
    IIncomeRepository repository)
    : IQueryHandler<GetIncomesQuery, IEnumerable<IncomeResponse>>
{
    public async Task<Result<IEnumerable<IncomeResponse>>> Handle(GetIncomesQuery request, CancellationToken cancellationToken)
    {
        var incomes = await repository.GetAllAsync();
        var incomesResponse = incomes.ToResponses();

        return Result.Success(incomesResponse);
    }
}
