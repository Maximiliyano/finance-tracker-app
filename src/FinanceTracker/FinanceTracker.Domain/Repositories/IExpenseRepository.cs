using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Domain.Repositories;

public interface IExpenseRepository
{
    Task<Expense?> GetAsync(ISpecification<Expense> specification);
    
    Task<IEnumerable<Expense>> GetAllAsync();

    void Create(Expense expense);

    void Update(Expense expense);

    void Delete(Expense expense);
    
}
