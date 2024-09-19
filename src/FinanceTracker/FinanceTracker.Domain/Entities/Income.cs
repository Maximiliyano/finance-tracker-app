using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Domain.Entities;

public sealed class Income : Entity, IAuditableEntity, ISoftDeletableEntity
{
    public required float Amount { get; set; }

    public string Purpose { get; set; } = null!;

    public IncomeType Type { get; set; }

    public DateTimeOffset CreatedAt { get; init; }

    public int CreatedBy { get; init; }

    public DateTimeOffset? UpdatedAt { get; init; }

    public int? UpdatedBy { get; init; }

    public DateTimeOffset? DeletedAt { get; init; }

    public bool? IsDeleted { get; init; }

    public int? CapitalId { get; init; }

    public Capital? Capital { get; init; }
}