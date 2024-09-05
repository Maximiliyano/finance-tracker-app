using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Exchanges.Responses;
using FinanceTracker.Application.Exchanges.Service;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Exchanges.Queries.GetAll;

internal sealed class GetAllExchangeQueryHandler(IExchangeHttpService service)
    : IQueryHandler<GetAllExchangeQuery, IEnumerable<ExchangeResponse>>
{
    public async Task<Result<IEnumerable<ExchangeResponse>>> Handle(GetAllExchangeQuery request, CancellationToken cancellationToken)
    {
        var exchanges = await service.GetCurrencyAsync();

        if (!exchanges.IsSuccess)
        {
            return Result.Failure<IEnumerable<ExchangeResponse>>(exchanges.Errors);
        }

        return Result.Success(exchanges.Value
            .Select(e => new ExchangeResponse(e.CurrencyCode, e.NationalCurrencyCode, e.Buy, e.Sale)));
    }
}
