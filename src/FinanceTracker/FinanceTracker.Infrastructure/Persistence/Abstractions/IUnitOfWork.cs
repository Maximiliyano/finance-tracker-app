using System.Data;

namespace FinanceTracker.Infrastructure.Persistence.Abstractions;

public interface IUnitOfWork
{
    Task<IDbTransaction> BeginTransactionAsync();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}