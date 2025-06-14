using System.Linq.Expressions;

namespace Deed.Domain.Repositories;

public interface ISpecification<TEntity>
{
    Expression<Func<TEntity, bool>>? Criteria { get; }

    IList<Expression<Func<TEntity, object>>>? Includes { get; }
}
