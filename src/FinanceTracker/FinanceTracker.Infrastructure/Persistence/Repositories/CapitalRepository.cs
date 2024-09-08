using FinanceTracker.Domain.Constants;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Infrastructure.Persistence.Repositories;

internal sealed class CapitalRepository(
    FinanceTrackerDbContext context)
    : GeneralRepository<Capital>(context), ICapitalRepository
{
    public new async Task<IEnumerable<Capital>> GetAllAsync()
    {
        var capitals = await DbContext.Capitals.AsNoTracking().ToListAsync();

        return capitals;
    }

    public new async Task<Capital?> GetAsync(ISpecification<Capital> specification)
    {
        var capital = await base.GetAsync(specification);

        if (capital is null)
        {
            return capital;
        }

        capital.TotalExpense = capital.Expenses?.Sum(e => e.Amount) ?? ValidationConstants.ZeroValue;
        capital.TotalIncome = capital.Incomes?.Sum(i => i.Amount) ?? ValidationConstants.ZeroValue;
        capital.TotalTransferIn = capital.TransfersIn?.Sum(t => t.Amount) ?? ValidationConstants.ZeroValue;
        capital.TotalTransferOut = capital.TransfersOut?.Sum(t => t.Amount) ?? ValidationConstants.ZeroValue;

        return capital;
    }

    public new void Create(Capital capital)
        => base.Create(capital);

    public new void Update(Capital capital)
        => base.Update(capital);

    public new async Task<int> DeleteAsync(int id)
        => await base.DeleteAsync(id);

    public new async Task<bool> AnyAsync(ISpecification<Capital> specification)
        => await base.AnyAsync(specification);
}