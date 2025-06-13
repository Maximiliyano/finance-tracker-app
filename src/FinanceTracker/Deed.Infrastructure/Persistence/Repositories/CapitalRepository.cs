using FinanceTracker.Application.Abstractions.Data;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Repositories;

namespace FinanceTracker.Infrastructure.Persistence.Repositories;

internal sealed class CapitalRepository(
    IFinanceTrackerDbContext context)
    : GeneralRepository<Capital>(context), ICapitalRepository
{
    public new async Task<IEnumerable<Capital>> GetAllAsync()
        => await base.GetAllAsync();

    public new async Task<Capital?> GetAsync(ISpecification<Capital> specification)
        => await base.GetAsync(specification);

    public new void Create(Capital capital)
        => base.Create(capital);

    public new void Update(Capital capital)
        => base.Update(capital);

    public new void Delete(Capital capital)
        => base.Delete(capital);

    public new async Task<bool> AnyAsync(ISpecification<Capital> specification)
        => await base.AnyAsync(specification);
}
