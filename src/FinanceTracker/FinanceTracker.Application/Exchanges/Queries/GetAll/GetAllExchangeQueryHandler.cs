using FinanceTracker.Application.Abstractions.Messaging;
using FinanceTracker.Application.Exchanges.Responses;
using FinanceTracker.Application.Exchanges.Service;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Exchanges.Queries.GetAll;

internal sealed class GetAllExchangeQueryHandler(IExchangeHttpService service)
    : IQueryHandler<GetAllExchangeQuery, IEnumerable<ExchangeResponse>>
{
    public async Task<Result<IEnumerable<ExchangeResponse>>> Handle(GetAllExchangeQuery query, CancellationToken cancellationToken)
    {
        var result = await service.GetCurrencyAsync();

        return !result.IsSuccess
            ? Result.Failure<IEnumerable<ExchangeResponse>>(result.Errors)
            : Result.Success(result.Value.ToResponses());
    }
}
