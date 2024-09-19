using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Capitals.Responses;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Capitals.Queries.GetAll;

public sealed class GetAllCapitalsQueryHandler(
    ICapitalRepository repository)
    : IQueryHandler<GetAllCapitalsQuery, IEnumerable<CapitalResponse>>
{
    public async Task<Result<IEnumerable<CapitalResponse>>> Handle(GetAllCapitalsQuery request, CancellationToken cancellationToken)
    {
        var capitals = await repository.GetAllAsync();

        var capitalResponses = capitals.ToResponses();

        return Result.Success(capitalResponses);
    }
}
