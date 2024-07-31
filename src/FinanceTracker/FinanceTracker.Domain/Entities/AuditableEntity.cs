namespace FinanceTracker.Domain.Entities;

public abstract class AuditableEntity : Entity
{
    public DateTimeOffset CreatedAt { get; init; }

    public int CreatedBy { get; init; }

    public DateTimeOffset? UpdatedAt { get; init; }

    public int? UpdatedBy { get; init; }
}