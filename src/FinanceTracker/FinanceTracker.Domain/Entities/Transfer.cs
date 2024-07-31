namespace FinanceTracker.Domain.Entities;

public sealed class Transfer : AuditableEntity, ISoftDeletableEntity
{
    public required DateTimeOffset DeletedAt { get; init; }

    public required bool IsDeleted { get; init; }

    public int? AccountId { get; init; }
}