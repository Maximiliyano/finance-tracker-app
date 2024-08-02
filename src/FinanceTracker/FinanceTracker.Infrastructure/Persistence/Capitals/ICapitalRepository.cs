using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Infrastructure.Persistence.Accounts;

public interface ICapitalRepository
{
    Task<IEnumerable<Account>> GetAll();
}