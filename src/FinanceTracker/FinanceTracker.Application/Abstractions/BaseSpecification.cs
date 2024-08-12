using System.Linq.Expressions;
using FinanceTracker.Domain.Repositories;

namespace FinanceTracker.Application.Abstractions;

internal abstract class BaseSpecification<TEntity>(Expression<Func<TEntity, bool>>? criteria = null)
    : ISpecification<TEntity>
{
    public Expression<Func<TEntity, bool>>? Criteria { get; init; } = criteria;
}