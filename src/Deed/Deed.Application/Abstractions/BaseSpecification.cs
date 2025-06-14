using System.Linq.Expressions;
using Deed.Domain.Entities;
using Deed.Domain.Repositories;

namespace Deed.Application.Abstractions;

internal abstract class BaseSpecification<TEntity>(
    Expression<Func<TEntity, bool>>? criteria = null)
    : ISpecification<TEntity>
    where TEntity : Entity
{
    public Expression<Func<TEntity, bool>>? Criteria { get; protected init; } = criteria;

    public IList<Expression<Func<TEntity, object>>> Includes { get; } = [];

    protected void AddInclude(Expression<Func<TEntity, object>> include)
        => Includes.Add(include);
}
