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
    public async Task<IEnumerable<Category>> GetAllAsync(CategoryType? type)
        => await DbContext.Categories
            .Where(c => !type.HasValue || c.Type == type.Value)
            .AsNoTracking()
            .ToListAsync();

    public new async Task<Category?> GetAsync(ISpecification<Category> specification)
        => await base.GetAsync(specification);

    public new void Create(Category category)
        => base.Create(category);

    public new void Update(Category category)
        => base.Update(category);

    public new void Delete(Category category)
        => base.Delete(category);

    public new async Task<bool> AnyAsync(ISpecification<Category> specification)
        => await base.AnyAsync(specification);
}
