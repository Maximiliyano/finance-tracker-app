namespace Deed.Domain.Entities;

public interface IAuditableEntity
{
    DateTimeOffset CreatedAt { get; init; }

    int CreatedBy { get; init; }

    DateTimeOffset? UpdatedAt { get; init; }

    int? UpdatedBy { get; init; }
}
