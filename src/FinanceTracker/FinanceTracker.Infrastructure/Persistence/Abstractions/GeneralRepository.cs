using FinanceTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Infrastructure.Persistence.Abstractions;

internal abstract class GeneralRepository<TEntity>(IDbContext context)
    where TEntity : Entity
{
    protected IDbContext DbContext { get; } = context;

    protected async Task<IEnumerable<TEntity>> GetAllAsync() =>
        await DbContext.Set<TEntity>()
            .AsNoTracking()
            .ToListAsync();

    protected void Add(TEntity entity) =>
        DbContext.Add(entity);

    protected void Remove(TEntity entity) =>
        DbContext.Remove(entity);
}