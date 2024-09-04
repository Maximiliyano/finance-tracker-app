using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Exchange.Queries.GetAll;

internal sealed class GetAllExchangeQueryHandler(IExchangeHttpService service)
    : IQueryHandler<GetAllExchangeQuery, IEnumerable<Exchange>>
{
    public async Task<Result<IEnumerable<Exchange>>> Handle(GetAllExchangeQuery request, CancellationToken cancellationToken)
    {
        return await service.GetCurrencyAsync();
    }
}
