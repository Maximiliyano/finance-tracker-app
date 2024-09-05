using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Domain.Repositories;

public interface IIncomeRepository
{
    Task<Income?> GetAsync(ISpecification<Income> specification);

    void Create(Income income);

    Task<int> DeleteAsync(int id);
}