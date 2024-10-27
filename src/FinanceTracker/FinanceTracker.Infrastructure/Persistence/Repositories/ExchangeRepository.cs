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

    public async Task<IEnumerable<Exchange>> GetLatestAsync()
        => await DbContext.Set<Exchange>()
            .AsNoTracking()
            .OrderBy(x => x.CreatedAt)
            .Take(2)
            .ToListAsync();
}
