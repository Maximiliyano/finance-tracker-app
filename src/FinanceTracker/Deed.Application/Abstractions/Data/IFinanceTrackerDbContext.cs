using FinanceTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Application.Abstractions.Data;

public interface IFinanceTrackerDbContext
{
    DbSet<Capital> Capitals { get; }

    DbSet<Category> Categories { get; }

    DbSet<Transfer> Transfers { get; }

    DbSet<Income> Incomes { get; }

    DbSet<Expense> Expenses { get; }

    DbSet<Exchange> Exchanges { get; }

    DbSet<TEntity> Set<TEntity>()
        where TEntity : Entity;
}
