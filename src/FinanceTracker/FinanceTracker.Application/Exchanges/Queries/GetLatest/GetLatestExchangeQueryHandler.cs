using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Exchanges.Responses;
using FinanceTracker.Application.Exchanges.Service;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Exchanges.Queries.GetLatest;

public sealed class GetLatestExchangeQueryHandler(
    IExchangeHttpService service,
    IExchangeRepository repository)
    : IQueryHandler<GetLatestExchangeQuery, IEnumerable<ExchangeResponse>>
{
    public async Task<Result<IEnumerable<ExchangeResponse>>> Handle(GetLatestExchangeQuery request, CancellationToken cancellationToken)
    {
        var latestExchanges = repository
            .GetLatest()
            .Select(x => new ExchangeResponse(x.TargetCurrencyCode, x.NationalCurrencyCode, x.Buy, x.Sale));

        if (latestExchanges.Count() < 2)
        {
            var result = await service.GetCurrencyAsync();

            if (!result.IsSuccess)
            {
                return Result.Failure<IEnumerable<ExchangeResponse>>(result.Errors);
            }
            
            var actualExchanges = result.Value
                .OrderBy(x => x.CreatedAt)
                .Take(2)
                .Select(x => new ExchangeResponse(x.TargetCurrencyCode, x.NationalCurrencyCode, x.Buy, x.Sale));

            return Result.Success(actualExchanges);
        }

        return Result.Success(latestExchanges);
    }
}
