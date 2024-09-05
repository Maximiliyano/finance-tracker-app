using System.Linq.Expressions;

namespace FinanceTracker.Domain.Repositories;

public interface ISpecification<TEntity>
{
    Expression<Func<TEntity, bool>>? Criteria { get; }

    IList<Expression<Func<TEntity, object>>>? Includes { get; }
}