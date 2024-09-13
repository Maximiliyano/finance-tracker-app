using System.Security.Cryptography;
using FinanceTracker.Domain.Constants;

namespace FinanceTracker.Domain.Entities;

public sealed class Capital
    : Entity, IAuditableEntity, ISoftDeletableEntity
{
    public Capital(int id)
        : base(id)
    {
    }

    public Capital()
    {
    }

    public string Name { get; set; } = null!;

    public float Balance { get; set; }

    public float TotalIncome { get; set; }

    public float TotalExpense { get; set; }

    public float TotalTransferIn { get; set; }

    public float TotalTransferOut { get; set; }

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
