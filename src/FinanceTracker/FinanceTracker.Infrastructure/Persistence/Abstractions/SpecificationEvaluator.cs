using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Repositories;

namespace FinanceTracker.Infrastructure.Persistence.Abstractions;

public static class SpecificationEvaluator
{
    public static IQueryable<TEntity> GetQuery<TEntity>(
        IQueryable<TEntity> queryable,
        ISpecification<TEntity>? specification = null)
            where TEntity : Entity
    {
        return queryable;
    }
}