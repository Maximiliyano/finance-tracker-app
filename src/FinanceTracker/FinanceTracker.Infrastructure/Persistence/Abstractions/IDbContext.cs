using FinanceTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Infrastructure.Persistence.Abstractions;

public interface IDbContext
{
    DbSet<TEntity> Set<TEntity>()
        where TEntity : Entity;

    void Add<TEntity>(TEntity entity)
        where TEntity : Entity;

    void Remove<TEntity>(TEntity entity)
        where TEntity : Entity;
}