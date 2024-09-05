using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Exchanges.Service;

public interface IExchangeHttpService
{
    Task<Result<IEnumerable<Exchange>>> GetCurrencyAsync();
}