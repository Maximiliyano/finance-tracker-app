using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Domain.Repositories;

public interface IExchangeRepository
{
    void AddRange(IEnumerable<Exchange> exchanges);

    Task<IEnumerable<Exchange>> GetLatestAsync();
}
