using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Exchanges.Responses;
using FinanceTracker.Application.Exchanges.Service;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Exchanges.Queries.GetLatest;

public sealed class GetLatestExchangeQueryHandler(
    IExchangeHttpService service,
    IExchangeRepository repository,
    IUnitOfWork unitOfWork)
    : IQueryHandler<GetLatestExchangeQuery, IEnumerable<ExchangeResponse>>
{
    public async Task<Result<IEnumerable<ExchangeResponse>>> Handle(GetLatestExchangeQuery query, CancellationToken cancellationToken)
    {
        var exchanges = await repository.GetLatestAsync();

        if (!exchanges.Any())
        {
            var result = await service.GetCurrencyAsync();

            if (!result.IsSuccess)
            {
                return Result.Failure<IEnumerable<ExchangeResponse>>(result.Errors);
            }

            var actualExchanges = result.Value.ToList();

            repository.AddRange(actualExchanges);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(actualExchanges.ToResponses());
        }

        return Result.Success(exchanges.ToResponses());
    }
}
