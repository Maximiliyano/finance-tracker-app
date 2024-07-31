using FinanceTracker.Domain.Entities;
using FinanceTracker.Infrastructure.Persistence.Abstractions;

namespace FinanceTracker.Infrastructure.Persistence.Accounts;

internal sealed class AccountRepository(
    FinanceTrackerDbContext context)
    : GeneralRepository<Account>(context), IAccountRepository
{
    public new async Task<IEnumerable<Account>> GetAll()
        => await base.GetAll();
}