using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Repositories;

namespace FinanceTracker.Infrastructure.Persistence.Repositories;

internal sealed class ExpenseRepository(
    FinanceTrackerDbContext context) : GeneralRepository<Expense>(context), IExpenseRepository
{
    public new async Task<Expense?> GetAsync(ISpecification<Expense> specification)
        => await base.GetAsync(specification);

    public new void Create(Expense expense)
        => base.Create(expense);

    public new async Task<int> DeleteAsync(int id)
        => await base.DeleteAsync(id);
}