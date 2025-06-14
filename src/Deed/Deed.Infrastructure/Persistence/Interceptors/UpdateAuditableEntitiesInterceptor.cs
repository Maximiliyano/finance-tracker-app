using Deed.Domain.Entities;
using Deed.Domain.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Deed.Infrastructure.Persistence.Interceptors;

internal sealed class UpdateAuditableEntitiesInterceptor(IDateTimeProvider dateTimeProvider)
    : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context is not null)
        {
            UpdateAuditableEntities(eventData.Context);
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void UpdateAuditableEntities(DbContext context)
    {
        var entries = context
            .ChangeTracker
            .Entries<IAuditableEntity>()
            .ToList();

        foreach (EntityEntry<IAuditableEntity> entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                SetCurrentPropertyValue(entry, nameof(IAuditableEntity.CreatedAt), dateTimeProvider.UtcNow);
            }

            if (entry.State == EntityState.Modified)
            {
                SetCurrentPropertyValue(entry, nameof(IAuditableEntity.UpdatedAt), dateTimeProvider.UtcNow);
            }
        }
    }

    private static void SetCurrentPropertyValue(
        EntityEntry entry,
        string propertyName,
        DateTimeOffset utcNow)
            => entry.Property(propertyName).CurrentValue = utcNow;
}
