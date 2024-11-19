using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Domain.Entities;

public sealed class Capital
    : Entity, IAuditableEntity, ISoftDeletableEntity
{
    public Capital(int? id)
        : base(id ?? 0)
    {
    }

    public Capital(int id)
        : base(id)
    {
    }

    public Capital()
    {
    }

    public string Name { get; set; } = null!;

    public float Balance { get; set; }

    public CurrencyType Currency { get; set; }

    public float TotalIncome => Incomes?.Sum(i => i.Amount) ?? 0;

    public float TotalExpense => Expenses?.Sum(e => e.Amount) ?? 0;

    public float TotalTransferIn => TransfersIn?.Sum(t => t.Amount) ?? 0;

    public float TotalTransferOut => TransfersOut?.Sum(t => t.Amount) ?? 0;

    public DateTimeOffset CreatedAt { get; init; }

    public int CreatedBy { get; init; }

    public DateTimeOffset? UpdatedAt { get; init; }

    public int? UpdatedBy { get; init; }

    public DateTimeOffset? DeletedAt { get; init; }

    public bool? IsDeleted { get; init; }

    public IEnumerable<Income>? Incomes { get; init; }

    public IEnumerable<Expense>? Expenses { get; init; }

    public IEnumerable<Transfer>? TransfersIn { get; init; }

    public IEnumerable<Transfer>? TransfersOut { get; init; }
}
