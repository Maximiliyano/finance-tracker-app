using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Enums;
using FinanceTracker.Infrastructure.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTracker.Infrastructure.Persistence.Configurations;

internal sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasData(DefaultCategories());
        
        builder.ToTable(TableConfigurationConstants.Categories);
    }
        
    private static IEnumerable<Category> DefaultCategories()
    {
        var utcNow = DateTimeOffset.UtcNow;
        
        return [
            new Category(1)
            {
                Name = "Groceries",
                Type = CategoryType.Expenses,
                CreatedAt = utcNow
            },
            new Category(2)
            {
                Name = "Utilities",
                Type = CategoryType.Expenses,
                CreatedAt = utcNow
            },
            new Category(3)
            {
                Name = "Rent",
                Type = CategoryType.Expenses,
                CreatedAt = utcNow
            },
            new Category(4)
            {
                Name = "Transportation",
                Type = CategoryType.Expenses,
                CreatedAt = utcNow
            },
            new Category(5)
            {
                Name = "Healthcare",
                Type = CategoryType.Expenses,
                CreatedAt = utcNow
            },
            new Category(6)
            {
                Name = "Entertainment",
                Type = CategoryType.Expenses,
                CreatedAt = utcNow
            },
            new Category(7)
            {
                Name = "Education",
                Type = CategoryType.Expenses,
                CreatedAt = utcNow
            },
            new Category(8)
            {
                Name = "Clothing",
                Type = CategoryType.Expenses,
                CreatedAt = utcNow
            },
            new Category(9)
            {
                Name = "Subscriptions",
                Type = CategoryType.Expenses,
                CreatedAt = utcNow
            },
            new Category(10)
            {
                Name = "Travel",
                Type = CategoryType.Expenses,
                CreatedAt = utcNow
            },
            new Category(11)
            {
                Name = "Gifts",
                Type = CategoryType.Expenses,
                CreatedAt = utcNow
            },
            new Category(12)
            {
                Name = "Donations",
                Type = CategoryType.Expenses,
                CreatedAt = utcNow
            },
            new Category(13)
            {
                Name = "Salary",
                Type = CategoryType.Incomes,
                CreatedAt = utcNow
            },
            new Category(14)
            {
                Name = "Gifts",
                Type = CategoryType.Incomes,
                CreatedAt = utcNow
            },
            new Category(15)
            {
                Name = "Grants",
                Type = CategoryType.Incomes,
                CreatedAt = utcNow
            },
            new Category(16)
            {
                Name = "Sales",
                Type = CategoryType.Incomes,
                CreatedAt = utcNow
            }
        ];
    }
}
