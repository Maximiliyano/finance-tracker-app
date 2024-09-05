using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Repositories;

namespace FinanceTracker.Infrastructure.Persistence.Repositories;

internal sealed class IncomeRepository(
    FinanceTrackerDbContext context) : GeneralRepository<Income>(context), IIncomeRepository
{
    public new async Task<Income?> GetAsync(ISpecification<Income> specification)
        => await base.GetAsync(specification);

    public new void Create(Income income)
        => base.Create(income);

    public new async Task<int> DeleteAsync(int id)
        => await base.DeleteAsync(id);
}