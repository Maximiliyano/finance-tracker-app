using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Exchange;

public interface IExchangeHttpService
{
    Task<Result<IEnumerable<Exchange>>> GetCurrencyAsync();
}