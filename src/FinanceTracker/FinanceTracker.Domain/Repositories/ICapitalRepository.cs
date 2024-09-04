using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Domain.Repositories;

public interface ICapitalRepository
{
    Task<IEnumerable<Capital>> GetAllAsync();

    Task<Capital?> GetAsync(ISpecification<Capital> specification);

    void Add(Capital capital);

    Task<bool> AnyAsync(ISpecification<Capital> specification);
}