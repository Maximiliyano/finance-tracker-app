using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Capitals.Responses;
using FinanceTracker.Application.Capitals.Specifications;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Capitals.Queries.GetById;

internal sealed class GetByIdCapitalQueryHandler(ICapitalRepository repository)
    : IQueryHandler<GetByIdCapitalQuery, CapitalResponse>
{
    public async Task<Result<CapitalResponse>> Handle(GetByIdCapitalQuery request, CancellationToken cancellationToken)
    {
        var capital = await repository.GetAsync(new CapitalByIdSpecification(request.Id));

        if (capital is null)
        {
            return Result.Failure<CapitalResponse>(DomainErrors.Capital.NotFound);
        }

        var capitalResponse = new CapitalResponse(
            capital.Id,
            capital.Name,
            capital.Balance,
            capital.TotalIncome,
            capital.TotalExpense,
            capital.TotalTransferIn,
            capital.TotalTransferOut);

        return Result.Success(capitalResponse);
    }
}
