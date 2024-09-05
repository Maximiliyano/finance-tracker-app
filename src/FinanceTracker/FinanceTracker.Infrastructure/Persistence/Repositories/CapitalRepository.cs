using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Repositories;

namespace FinanceTracker.Infrastructure.Persistence.Repositories;

internal sealed class CapitalRepository(
    FinanceTrackerDbContext context)
    : GeneralRepository<Capital>(context), ICapitalRepository
{
    public new async Task<IEnumerable<Capital>> GetAllAsync()
        => await base.GetAllAsync();

    public new async Task<Capital?> GetAsync(ISpecification<Capital> specification)
    {
        var capital = await base.GetAsync(specification);

        if (capital is null)
        {
            return capital;
        }

        capital.TotalExpense = capital.Expenses?.Sum(e => e.Amount) ?? 0;
        capital.TotalIncome = capital.Incomes?.Sum(i => i.Amount) ?? 0;
        capital.TotalTransferIn = capital.TransfersIn?.Sum(t => t.Amount) ?? 0;
        capital.TotalTransferOut = capital.TransfersOut?.Sum(t => t.Amount) ?? 0;

        return capital;
    }

    public new void Create(Capital capital)
        => base.Create(capital);

    public new async Task<int> UpdateAsync(int id, Capital capital)
        => await base.UpdateAsync(id, capital);

    public new async Task<int> DeleteAsync(int id)
        => await base.DeleteAsync(id);

    public new async Task<bool> AnyAsync(ISpecification<Capital> specification)
        => await base.AnyAsync(specification);
}