using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Domain.Repositories;

public interface ICapitalRepository
{
    Task<IEnumerable<Capital>> GetAllAsync();

    Task<Capital?> GetAsync(ISpecification<Capital> specification);

    void Create(Capital capital);

    void Update(Capital capital);

    void Delete(Capital capital);

    Task<bool> AnyAsync(ISpecification<Capital> specification);
}
