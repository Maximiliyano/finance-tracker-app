namespace FinanceTracker.Domain.Entities;

public sealed class Income : Entity, IAuditableEntity, ISoftDeletableEntity
{
    public DateTimeOffset CreatedAt { get; init; }

    public int CreatedBy { get; init; }

    public DateTimeOffset? UpdatedAt { get; init; }

    public int? UpdatedBy { get; init; }

    public DateTimeOffset DeletedAt { get; init; }

    public bool IsDeleted { get; init; }

    public int? AccountId { get; init; }
}