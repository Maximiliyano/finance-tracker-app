using FinanceTracker.Application.Abstractions.Data;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Infrastructure.Persistence.Repositories;

internal sealed class ExchangeRepository(
    IFinanceTrackerDbContext context)
    : GeneralRepository<Exchange>(context), IExchangeRepository
{
    public void AddRange(IEnumerable<Exchange> exchanges)
        => CreateRange(exchanges);

    public new void UpdateRange(IEnumerable<Exchange> updatedExchanges)
        => base.UpdateRange(updatedExchanges);

    public void RemoveRange(IEnumerable<Exchange> exchanges)
        => DeleteRange(exchanges);

    public new async Task<IEnumerable<Exchange>> GetAllAsync()
        => await DbContext.Set<Exchange>()
            .AsNoTracking()
            .OrderBy(x => x.CreatedAt)
            .ToListAsync();
}
