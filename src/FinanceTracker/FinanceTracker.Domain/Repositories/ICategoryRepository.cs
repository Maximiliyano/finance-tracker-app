using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Domain.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync(CategoryType? type);

    Task<Category?> GetAsync(ISpecification<Category> specification);

    void Create(Category category);

    void Update(Category category);

    void Delete(Category category);

    Task<bool> AnyAsync(ISpecification<Category> specification);
}
