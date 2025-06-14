namespace Deed.Domain.Entities;

public interface ISoftDeletableEntity
{
    DateTimeOffset? DeletedAt { get; init; }

    bool? IsDeleted { get; init; }
}
