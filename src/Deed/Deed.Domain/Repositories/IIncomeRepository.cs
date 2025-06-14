using Deed.Domain.Entities;

namespace Deed.Domain.Repositories;

public interface IIncomeRepository
{
    Task<Income?> GetAsync(ISpecification<Income> specification);

    Task<IEnumerable<Income>> GetAllAsync();

    void Create(Income income);

    void Update(Income income);

    void Delete(Income income);
}
