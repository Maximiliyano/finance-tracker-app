using Deed.Application.Abstractions.Data;
using Deed.Domain.Entities;
using Deed.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Deed.Infrastructure.Persistence.Repositories;

internal sealed class ExchangeRepository(
    IDeedDbContext context)
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
