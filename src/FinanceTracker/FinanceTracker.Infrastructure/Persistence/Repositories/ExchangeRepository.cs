using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Infrastructure.Persistence.Repositories;

internal sealed class ExchangeRepository(
    FinanceTrackerDbContext context)
    : GeneralRepository<Exchange>(context), IExchangeRepository
{
    public void AddRange(IEnumerable<Exchange> exchanges)
        => CreateRange(exchanges);

    public IEnumerable<Exchange> GetLatest()
        => DbContext.Exchanges
            .AsNoTracking()
            .OrderBy(x => x.CreatedAt)
            .Take(2);
}
