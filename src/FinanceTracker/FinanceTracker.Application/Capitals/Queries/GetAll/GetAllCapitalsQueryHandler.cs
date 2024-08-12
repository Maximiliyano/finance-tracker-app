using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Capitals.Queries.GetAll;

internal sealed class GetAllCapitalsQueryHandler(
    ICapitalRepository repository)
    : IQueryHandler<GetAllCapitalsQuery, IEnumerable<Capital>>
{
    public async Task<Result<IEnumerable<Capital>>> Handle(GetAllCapitalsQuery request, CancellationToken cancellationToken)
    {
        var capitals = await repository.GetAllAsync();

        return Result.Success(capitals);
    }
}