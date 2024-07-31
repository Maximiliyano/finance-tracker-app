using FinanceTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Infrastructure.Persistence.Abstractions;

internal abstract class GeneralRepository<TEntity>(FinanceTrackerDbContext context)
    where TEntity : Entity
{
    protected FinanceTrackerDbContext DbContext { get; } = context;

    protected async Task<IEnumerable<TEntity>> GetAll() =>
        await DbContext.Set<TEntity>()
            .AsNoTracking()
            .ToListAsync();

    protected void Add(TEntity entity) =>
        DbContext.Set<TEntity>().Add(entity);

    protected void Remove(TEntity entity) =>
        DbContext.Set<TEntity>().Remove(entity);
}