using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Infrastructure.Persistence;

public sealed class FinanceTrackerDbContext(DbContextOptions options) : DbContext(options), IUnitOfWork
{
    public DbSet<Capital> Capitals { get; init; } = null!;

    public DbSet<Transfer> Transfers { get; init; } = null!;

    public DbSet<Income> Incomes { get; init; } = null!;

    public DbSet<Expense> Expenses { get; init; } = null!;

    public new DbSet<TEntity> Set<TEntity>()
        where TEntity : Entity =>
            base.Set<TEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
    }
}
