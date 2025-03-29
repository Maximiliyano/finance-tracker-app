using FinanceTracker.Domain.Entities;
using FinanceTracker.Infrastructure.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTracker.Infrastructure.Persistence.Configurations;

internal sealed class CapitalConfiguration : IEntityTypeConfiguration<Capital>
{
    public void Configure(EntityTypeBuilder<Capital> builder)
    {
        builder.HasKey(c => c.Id);

        builder
            .HasIndex(c => c.Name)
            .IsUnique();

        builder
            .Property(c => c.Currency)
            .HasConversion<string>(); // TODO add pre-configured entities

        builder
            .HasMany(c => c.Incomes)
            .WithOne(i => i.Capital)
            .HasForeignKey(i => i.CapitalId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Navigation(c => c.Incomes)
            .AutoInclude();

        builder
            .HasMany(c => c.Expenses)
            .WithOne(e => e.Capital)
            .HasForeignKey(e => e.CapitalId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Navigation(c => c.Expenses)
            .AutoInclude();

        builder
            .HasMany(c => c.TransfersIn)
            .WithOne(t => t.DestinationCapital)
            .HasForeignKey(t => t.DestinationCapitalId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Navigation(c => c.TransfersIn)
            .AutoInclude();

        builder
            .HasMany(c => c.TransfersOut)
            .WithOne(t => t.SourceCapital)
            .HasForeignKey(t => t.SourceCapitalId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Navigation(c => c.TransfersOut)
            .AutoInclude();

        builder.ToTable(TableConfigurationConstants.Capitals);
    }
}
