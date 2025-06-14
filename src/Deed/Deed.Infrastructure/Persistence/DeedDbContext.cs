using Deed.Application.Abstractions.Data;
using Deed.Domain.Entities;
using Deed.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Deed.Infrastructure.Persistence;

public sealed class DeedDbContext(DbContextOptions<DeedDbContext> options)
    : DbContext(options),
        IDeedDbContext,
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
    }
}
