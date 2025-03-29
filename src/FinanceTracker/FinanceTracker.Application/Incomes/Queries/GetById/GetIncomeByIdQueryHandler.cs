using FinanceTracker.Application.Abstractions.Messaging;
using FinanceTracker.Application.Incomes.Responses;
using FinanceTracker.Application.Incomes.Specifications;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Incomes.Queries.GetById;

internal sealed class GetIncomeByIdQueryHandler(
    IIncomeRepository repository)
    : IQueryHandler<GetIncomeByIdQuery, IncomeResponse>
{
    public async Task<Result<IncomeResponse>> Handle(GetIncomeByIdQuery query, CancellationToken cancellationToken)
    {
        var income = await repository.GetAsync(new IncomeByIdSpecification(query.Id));

        if (income is null)
        {
            return Result.Failure<IncomeResponse>(DomainErrors.General.NotFound(nameof(income)));
        }

        var incomeResponse = income.ToResponse();

        return Result.Success(incomeResponse);
    }
}
