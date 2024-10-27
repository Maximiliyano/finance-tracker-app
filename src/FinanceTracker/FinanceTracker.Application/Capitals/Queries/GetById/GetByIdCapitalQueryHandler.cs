using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Capitals.Responses;
using FinanceTracker.Application.Capitals.Specifications;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Capitals.Queries.GetById;

internal sealed class GetByIdCapitalQueryHandler(ICapitalRepository repository)
    : IQueryHandler<GetByIdCapitalQuery, CapitalResponse>
{
    public async Task<Result<CapitalResponse>> Handle(GetByIdCapitalQuery query, CancellationToken cancellationToken)
    {
        var capital = await repository.GetAsync(new CapitalByIdSpecification(query.Id));

        if (capital is null)
        {
            return Result.Failure<CapitalResponse>(DomainErrors.General.NotFound(nameof(capital)));
        }

        var capitalResponse = capital.ToResponse();

        return Result.Success(capitalResponse);
    }
}
