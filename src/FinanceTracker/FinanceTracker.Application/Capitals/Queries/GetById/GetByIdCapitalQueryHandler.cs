using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Capitals.Specifications;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Capitals.Queries.GetById;

internal sealed class GetByIdCapitalQueryHandler(ICapitalRepository repository)
    : IQueryHandler<GetByIdCapitalQuery, Capital>
{
    public async Task<Result<Capital>> Handle(GetByIdCapitalQuery request, CancellationToken cancellationToken)
    {
        var capital = await repository.GetAsync(new CapitalByIdSpecification(request.Id));

        if (capital is null)
        {
            return Result.Failure<Capital>(DomainErrors.Capital.NotFound);
        }

        return Result.Success(capital);
    }
}
