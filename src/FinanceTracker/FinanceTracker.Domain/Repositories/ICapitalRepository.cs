using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Domain.Repositories;

public interface ICapitalRepository
{
    Task<IEnumerable<Capital>> GetAllAsync();

    Task<Capital?> GetAsync(ISpecification<Capital> specification);

    void Create(Capital capital);

    Task<int> UpdateAsync(int id, Capital capital);

    Task<int> DeleteAsync(int id);

    Task<bool> AnyAsync(ISpecification<Capital> specification);
}