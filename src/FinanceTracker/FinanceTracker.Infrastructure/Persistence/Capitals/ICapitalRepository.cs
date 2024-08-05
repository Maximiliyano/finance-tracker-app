using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Infrastructure.Persistence.Accounts;

public interface ICapitalRepository
{
    Task<IEnumerable<Capital>> GetAllAsync();

    void Create(Capital capital);

    void Delete(Capital capital);
}