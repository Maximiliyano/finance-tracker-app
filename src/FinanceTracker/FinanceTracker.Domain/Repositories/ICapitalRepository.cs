using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Domain.Repositories;

public interface ICapitalRepository
{
    Task<IEnumerable<Capital>> GetAll();
}