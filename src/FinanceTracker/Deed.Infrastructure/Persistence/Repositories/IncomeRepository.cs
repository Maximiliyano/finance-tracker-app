using FinanceTracker.Application.Abstractions.Data;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Repositories;

namespace FinanceTracker.Infrastructure.Persistence.Repositories;

internal sealed class IncomeRepository(
    IFinanceTrackerDbContext context)
    : GeneralRepository<Income>(context), IIncomeRepository
{
    public new async Task<Income?> GetAsync(ISpecification<Income> specification)
        => await base.GetAsync(specification);

    public new async Task<IEnumerable<Income>> GetAllAsync()
        => await base.GetAllAsync();

    public new void Create(Income income)
        => base.Create(income);

    public new void Update(Income income)
        => base.Update(income);

    public new void Delete(Income income)
        => base.Delete(income);
}
