using System.Data;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Infrastructure.Persistence.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace FinanceTracker.Infrastructure.Persistence;

public sealed class FinanceTrackerDbContext(DbContextOptions options) :
    DbContext(options),
    IDbContext,
    IUnitOfWork
{
    public async Task<IDbTransaction> BeginTransactionAsync()
    {
        var transaction = await Database.BeginTransactionAsync();

        return transaction.GetDbTransaction();
    }

    public new DbSet<TEntity> Set<TEntity>()
        where TEntity : Entity =>
            base.Set<TEntity>();

    public new void Add<TEntity>(TEntity entity)
        where TEntity : Entity =>
            Set<TEntity>().Add(entity);

    public new void Remove<TEntity>(TEntity entity)
        where TEntity : Entity =>
            Set<TEntity>().Remove(entity);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
    }
}