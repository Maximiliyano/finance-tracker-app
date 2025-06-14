using Deed.Application.Abstractions.Data;
using Deed.Domain.Entities;
using Deed.Domain.Repositories;
using Deed.Infrastructure.Persistence.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Deed.Infrastructure.Persistence.Repositories;

internal abstract class GeneralRepository<TEntity>(IDeedDbContext context)
    where TEntity : Entity, ISoftDeletableEntity
{
    protected IDeedDbContext DbContext { get; } = context;

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

    protected void UpdateRange(IEnumerable<TEntity> entities) =>
        DbContext.Set<TEntity>().UpdateRange(entities);

    protected void Delete(TEntity entity) =>
        DbContext.Set<TEntity>().Remove(entity);

    protected void DeleteRange(IEnumerable<TEntity> entities) =>
        DbContext.Set<TEntity>().RemoveRange(entities);

    protected async Task<bool> AnyAsync(ISpecification<TEntity> specification) =>
        await ApplySpecification(specification)
            .AnyAsync();

    private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity>? specification)
        => SpecificationEvaluator.GetQuery(
                DbContext.Set<TEntity>(), specification);
}
