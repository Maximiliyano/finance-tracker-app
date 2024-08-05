using FinanceTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTracker.Infrastructure.Persistence.Configurations;

internal sealed class CapitalConfiguration : IEntityTypeConfiguration<Capital>
{
    public void Configure(EntityTypeBuilder<Capital> builder)
    {
        builder.HasKey(c => c.Id);

        builder
            .HasMany(c => c.Incomes)
            .WithOne(i => i.Capital)
            .HasForeignKey(i => i.CapitalId);
    }
}