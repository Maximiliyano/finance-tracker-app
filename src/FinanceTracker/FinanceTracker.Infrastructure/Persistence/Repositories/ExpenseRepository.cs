using FinanceTracker.Application.Abstractions.Data;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Enums;
using FinanceTracker.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Infrastructure.Persistence.Repositories;

internal sealed class ExpenseRepository(
    IFinanceTrackerDbContext context)
    : GeneralRepository<Expense>(context), IExpenseRepository
{
    public new async Task<Expense?> GetAsync(ISpecification<Expense> specification)
        => await base.GetAsync(specification);

    public new async Task<IEnumerable<Expense>> GetAllAsync()
        => await DbContext.Expenses
            .AsNoTracking()
            .Select(e => new Expense(e.Id)
            {
                Amount = e.Amount,
                CapitalId = e.CapitalId,
                Capital = new Capital(e.Capital!.Id)
                {
                    Balance = e.Capital.Balance,
                    Name = e.Capital.Name,
                    Currency = e.Capital.Currency
                },
                CategoryId = e.CategoryId,
                Category = new Category(e.Category!.Id)
                {
                    Name = e.Category.Name,
                    Type = e.Category.Type
                },
                PaymentDate = e.PaymentDate,
            })
            .ToListAsync();

    public new void Create(Expense expense)
        => base.Create(expense);

    public new void Update(Expense expense)
        => base.Update(expense);

    public new void Delete(Expense expense)
        => base.Delete(expense);

    public new async Task<bool> AnyAsync(ISpecification<Expense> specification)
        => await base.AnyAsync(specification);
}
