using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Domain.Repositories;

public interface IExchangeRepository
{
    void AddRange(IEnumerable<Exchange> exchanges);
    
    IEnumerable<Exchange> GetLatest();
}
