using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Repositories;

namespace FinanceTracker.Infrastructure.Persistence.Repositories;

internal sealed class CapitalRepository(
    FinanceTrackerDbContext context)
    : GeneralRepository<Capital>(context), ICapitalRepository
{
    public new async Task<IEnumerable<Capital>> GetAllAsync()
        => await base.GetAllAsync();

    public new async Task<Capital?> GetAsync(ISpecification<Capital> specification)
        => await base.GetAsync(specification);

    public new void Add(Capital capital)
        => base.Add(capital);

    public new async Task<bool> AnyAsync(ISpecification<Capital> specification)
        => await base.AnyAsync(specification);
}