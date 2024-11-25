using FinanceTracker.Application.Abstractions.Data;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace FinanceTracker.Infrastructure.Persistence;

public sealed class FinanceTrackerDbContext(DbContextOptions<FinanceTrackerDbContext> options)
    : DbContext(options),
        IFinanceTrackerDbContext,
        IUnitOfWork
{
    public DbSet<Capital> Capitals { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Transfer> Transfers { get; set; }

    public DbSet<Income> Incomes { get; set; }

    public DbSet<Expense> Expenses { get; set; }

    public DbSet<Exchange> Exchanges { get; set; }

    public new DbSet<TEntity> Set<TEntity>()
        where TEntity : Entity
            => base.Set<TEntity>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.ConfigureWarnings(w =>
            w.Ignore(RelationalEventId.PendingModelChangesWarning));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
    }
}
