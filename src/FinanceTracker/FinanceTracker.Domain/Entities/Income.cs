namespace FinanceTracker.Domain.Entities;

public sealed class Income : AuditableEntity, ISoftDeletableEntity
{
    public required int Count { get; init; }

    public string? Description { get; init; }

    public DateTimeOffset DeletedAt { get; init; }

    public bool IsDeleted { get; init; }

    public int? CapitalId { get; init; }

    public Capital? Capital { get; init; }
}