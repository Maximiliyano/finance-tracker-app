using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Domain.Entities;

public sealed class Income : Entity, IAuditableEntity, ISoftDeletableEntity
{
    public required float Amount { get; init; }

    public string Purpose { get; init; } = null!;

    public IncomeType Type { get; init; }

    public DateTimeOffset CreatedAt { get; init; }

    public int CreatedBy { get; init; }

    public DateTimeOffset? UpdatedAt { get; init; }

    public int? UpdatedBy { get; init; }

    public DateTimeOffset? DeletedAt { get; init; }

    public bool? IsDeleted { get; init; }

    public int? CapitalId { get; init; }

    public Capital? Capital { get; init; }
}