using FinanceTracker.Application.Abstractions.Data;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Infrastructure.Persistence.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Infrastructure.Persistence.Repositories;

internal abstract class GeneralRepository<TEntity>(IFinanceTrackerDbContext context)
    where TEntity : Entity, ISoftDeletableEntity
{
    protected IFinanceTrackerDbContext DbContext { get; } = context;

    protected async Task<IEnumerable<TEntity>> GetAllAsync() =>
        await DbContext.Set<TEntity>()
            .AsNoTracking()
            .ToListAsync();

    protected async Task<TEntity?> GetAsync(ISpecification<TEntity> specification) =>
        await ApplySpecification(specification)
            .SingleOrDefaultAsync();

    protected void Create(TEntity entity) =>
        DbContext.Set<TEntity>().Add(entity);

    protected void CreateRange(IEnumerable<TEntity> entities) =>
        DbContext.Set<TEntity>().AddRange(entities);

    protected void Update(TEntity entity) =>
        DbContext.Set<TEntity>().Update(entity);

    protected void Delete(TEntity entity) =>
        DbContext.Set<TEntity>().Remove(entity);

    protected async Task<bool> AnyAsync(ISpecification<TEntity> specification) =>
        await ApplySpecification(specification)
            .AnyAsync();

    private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity>? specification)
        => SpecificationEvaluator.GetQuery(
                DbContext.Set<TEntity>(), specification);
}
