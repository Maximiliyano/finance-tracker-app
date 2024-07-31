using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Infrastructure.Persistence.Accounts;

public interface IAccountRepository
{
    Task<IEnumerable<Account>> GetAll();
}