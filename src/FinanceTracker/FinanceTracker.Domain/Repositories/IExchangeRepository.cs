using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Domain.Repositories;

public interface IExchangeRepository
{
    void AddRange(IEnumerable<Exchange> exchanges);

    void UpdateRange(IEnumerable<Exchange> updatedExchanges);

    void RemoveRange(IEnumerable<Exchange> exchanges);

    Task<IEnumerable<Exchange>> GetAllAsync();
}
