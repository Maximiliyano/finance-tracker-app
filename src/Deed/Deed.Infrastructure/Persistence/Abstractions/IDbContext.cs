using Deed.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Deed.Infrastructure.Persistence.Abstractions;

public interface IDbContext
{
    DbSet<TEntity> Set<TEntity>()
        where TEntity : Entity;
}
