using FinanceTracker.Domain.Entities;
using FinanceTracker.Infrastructure.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTracker.Infrastructure.Persistence.Configurations;

internal sealed class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.HasKey(e => e.Id);

        builder
            .HasOne(e => e.Category)
            .WithMany(c => c.Expenses)
            .HasForeignKey(e => e.CategoryId);

        builder
            .HasOne(e => e.Capital)
            .WithMany(c => c.Expenses)
            .HasForeignKey(e => e.CapitalId);

        builder.ToTable(TableConfigurationConstants.Expenses);
    }
}
