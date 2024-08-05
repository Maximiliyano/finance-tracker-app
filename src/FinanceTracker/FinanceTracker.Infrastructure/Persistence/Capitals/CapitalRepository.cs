using FinanceTracker.Domain.Entities;
using FinanceTracker.Infrastructure.Persistence.Abstractions;

namespace FinanceTracker.Infrastructure.Persistence.Accounts;

internal sealed class CapitalRepository(
    FinanceTrackerDbContext context)
    : GeneralRepository<Capital>(context), ICapitalRepository
{
    public void Create(Capital capital)
        => Add(capital);

    public void Delete(Capital capital)
        => Remove(capital);

    public new async Task<IEnumerable<Capital>> GetAllAsync()
        => await base.GetAllAsync();
}