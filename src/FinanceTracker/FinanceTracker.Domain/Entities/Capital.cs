namespace FinanceTracker.Domain.Entities;

public sealed class Capital(int id) : Entity(id), IAuditableEntity, ISoftDeletableEntity
{
    public required string Name { get; init; }

    public required float Balance { get; init; }

    public required float TotalIncome { get; init; }

    public required float TotalExpense { get; init; }

    public required float TotalTransferIn { get; init; }

    public required float TotalTransferOut { get; init; }

    public DateTimeOffset CreatedAt { get; init; }

    public int CreatedBy { get; init; }

    public DateTimeOffset? UpdatedAt { get; init; }

    public int? UpdatedBy { get; init; }

    public DateTimeOffset DeletedAt { get; init; }

    public bool IsDeleted { get; init; }

    public IEnumerable<Income>? Incomes { get; init; }

    public IEnumerable<Expense>? Expenses { get; init; }

    public IEnumerable<Transfer>? Transfers { get; init; }
}
