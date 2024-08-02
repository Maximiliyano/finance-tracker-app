using FinanceTracker.Domain.Entities;
using FinanceTracker.Infrastructure.Persistence.Abstractions;

namespace FinanceTracker.Infrastructure.Persistence.Accounts;

internal sealed class CapitalRepository(
    FinanceTrackerDbContext context)
    : GeneralRepository<Account>(context), ICapitalRepository
{
    public new async Task<IEnumerable<Account>> GetAll()
        => await base.GetAll();
}