using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Infrastructure.Persistence.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Infrastructure.Persistence.Repositories;

internal abstract class GeneralRepository<TEntity>(FinanceTrackerDbContext context)
    where TEntity : Entity, ISoftDeletableEntity
{
    protected FinanceTrackerDbContext DbContext { get; } = context;

    protected async Task<IEnumerable<TEntity>> GetAllAsync() =>
        await DbContext.Set<TEntity>()
            .AsNoTracking()
            .ToListAsync();

    protected async Task<TEntity?> GetAsync(ISpecification<TEntity> specification) =>
        await ApplySpecification(specification)
            .FirstOrDefaultAsync();

    protected void Create(TEntity entity) =>
        DbContext.Set<TEntity>().Add(entity);

    protected void Update(TEntity entity) =>
        DbContext.Set<TEntity>().Update(entity);

    protected async Task<int> DeleteAsync(int id) =>
        await DbContext.Set<TEntity>()
            .Where(x => x.Id == id)
            .ExecuteUpdateAsync(property => property
                .SetProperty(e => e.IsDeleted, true)
                .SetProperty(e => e.DeletedAt, DateTimeOffset.UtcNow));

    protected async Task<bool> AnyAsync(ISpecification<TEntity> specification) =>
        await ApplySpecification(specification)
            .AnyAsync();

    private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity>? specification)
        => SpecificationEvaluator.GetQuery(
                DbContext.Set<TEntity>(), specification);
}