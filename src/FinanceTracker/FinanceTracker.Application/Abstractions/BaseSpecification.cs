using System.Linq.Expressions;
using FinanceTracker.Domain.Repositories;

namespace FinanceTracker.Application.Abstractions;

internal abstract class BaseSpecification<TEntity>(
    Expression<Func<TEntity, bool>>? criteria = null,
    IList<Expression<Func<TEntity, object>>>? includes = null)
    : ISpecification<TEntity>
{
    public Expression<Func<TEntity, bool>>? Criteria { get; protected init; } = criteria;

    public IList<Expression<Func<TEntity, object>>>? Includes { get; protected init; } = includes;
}