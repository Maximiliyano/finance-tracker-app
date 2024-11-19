namespace FinanceTracker.Domain.Entities;

public sealed class Expense : Entity, IAuditableEntity, ISoftDeletableEntity
{
    public required float Amount { get; set; }

    public string? Purpose { get; set; }

    public DateTimeOffset PaymentDate { get; set; }

    public int CategoryId { get; set; }

    public int CapitalId { get; init; }

    public Category Category { get; init; }

    public Capital Capital { get; init; }

    public DateTimeOffset CreatedAt { get; init; }

    public int CreatedBy { get; init; }

    public DateTimeOffset? UpdatedAt { get; init; }

    public int? UpdatedBy { get; init; }

    public DateTimeOffset? DeletedAt { get; init; }

    public bool? IsDeleted { get; init; }
}
