using FinanceTracker.Application.Abstractions.Data;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Enums;
using FinanceTracker.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Infrastructure.Persistence.Repositories;

internal sealed class CategoryRepository(
    IFinanceTrackerDbContext context)
    : GeneralRepository<Category>(context), ICategoryRepository
{
    public new async Task<Category?> GetAsync(ISpecification<Category> specification)
        => await base.GetAsync(specification);

    public async Task<IEnumerable<Category>> GetAllAsync(CategoryType? type)
        => await DbContext.Categories
            .Where(c => !type.HasValue || c.Type == type.Value)
            .AsNoTracking()
            .AsSplitQuery()
            .Include(c => c.Expenses)
            .Include(c => c.Incomes)
            .Select(c => new Category(c.Id)
            {
                Name = c.Name,
                Type = c.Type,
                PlannedPeriodAmount = c.PlannedPeriodAmount,
                Period = c.Period,
                Expenses = c.Expenses!.Select(e => new Expense(e.Id)
                {
                    Amount = e.Amount,
                    PaymentDate = e.PaymentDate,
                    Purpose = e.Purpose,
                    CategoryId = e.CategoryId,
                    CapitalId = e.CapitalId
                }),
                Incomes = c.Incomes!.Select(i => new Income(i.Id)
                {
                    Amount = i.Amount,
                    PaymentDate = i.PaymentDate,
                    Purpose = i.Purpose,
                    CategoryId = i.CategoryId,
                    CapitalId = i.CapitalId
                })
            })
            .ToListAsync();

    public new void Create(Category category)
        => base.Create(category);

    public new void Update(Category category)
        => base.Update(category);

    public new void Delete(Category category)
        => base.Delete(category);

    public new async Task<bool> AnyAsync(ISpecification<Category> specification)
        => await base.AnyAsync(specification);
}
