namespace FinanceTracker.Domain.Entities;

public sealed class Capital(string name, float balance)
    : Entity, IAuditableEntity, ISoftDeletableEntity
{
    public string Name { get; init; } = name;

    public float Balance { get; init; } = balance;

    public float TotalIncome { get; init; }

    public float TotalExpense { get; init; }

    public float TotalTransferIn { get; init; }

    public float TotalTransferOut { get; init; }

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
