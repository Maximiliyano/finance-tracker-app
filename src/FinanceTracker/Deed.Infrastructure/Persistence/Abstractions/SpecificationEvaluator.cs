using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Infrastructure.Persistence.Abstractions;

public static class SpecificationEvaluator
{
    public static IQueryable<TEntity> GetQuery<TEntity>(
        IQueryable<TEntity> queryable,
        ISpecification<TEntity>? specification = null)
            where TEntity : Entity
    {
        if (specification is null)
        {
            return queryable;
        }

        if (specification.Criteria is not null)
        {
            queryable = queryable.Where(specification.Criteria);
        }

        if (specification.Includes is not null)
        {
            queryable = specification.Includes
                .Aggregate(
                    queryable,
                    (currect, includeExpression) =>
                        currect.Include(includeExpression))
                .AsSplitQuery();
        }

        return queryable;
    }
}
