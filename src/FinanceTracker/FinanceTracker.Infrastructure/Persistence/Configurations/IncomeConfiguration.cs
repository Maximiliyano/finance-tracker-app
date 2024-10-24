using FinanceTracker.Domain.Entities;
using FinanceTracker.Infrastructure.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTracker.Infrastructure.Persistence.Configurations;

internal sealed class IncomeConfiguration : IEntityTypeConfiguration<Income>
{
    public void Configure(EntityTypeBuilder<Income> builder)
    {
        builder.HasKey(i => i.Id);

        builder
            .HasOne(i => i.Category)
            .WithMany(c => c.Incomes)
            .HasForeignKey(i => i.CategoryId);

        builder.ToTable(TableConfigurationConstants.Incomes);
    }
}
