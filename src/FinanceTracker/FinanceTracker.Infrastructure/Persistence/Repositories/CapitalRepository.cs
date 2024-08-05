using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Infrastructure.Persistence.Repositories;

namespace FinanceTracker.Infrastructure.Persistence.Accounts;

internal sealed class CapitalRepository(
    FinanceTrackerDbContext context)
    : GeneralRepository<Capital>(context), ICapitalRepository
{
    public new async Task<IEnumerable<Capital>> GetAll()
        => await base.GetAll();
}