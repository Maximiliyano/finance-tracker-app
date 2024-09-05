using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Domain.Repositories;

public interface IExpenseRepository
{
    Task<Expense?> GetAsync(ISpecification<Expense> specification);

    void Create(Expense expense);

    Task<int> DeleteAsync(int id);
}