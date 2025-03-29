using FinanceTracker.Domain.Entities;
using FinanceTracker.Infrastructure.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTracker.Infrastructure.Persistence.Configurations;

internal sealed class ExchangeConfiguration : IEntityTypeConfiguration<Exchange>
{
    public void Configure(EntityTypeBuilder<Exchange> builder)
    {
        builder.HasKey(ex => ex.Id); // TODO add pre-configured exchanges

        builder.HasData(DefaultExchanges());

        builder.ToTable(TableConfigurationConstants.Exchanges);
    }

    private static IEnumerable<Exchange> DefaultExchanges()
    {
        var createdAt = new DateTimeOffset(2025, 03, 21, 19, 48, 39, TimeSpan.Zero);
        
        return
        [
            new(1)
            {
                NationalCurrencyCode = "UAH",
                TargetCurrencyCode = "EUR",
                Buy = 44.63f,
                Sale = 45.45455f,
                CreatedAt = createdAt
            },
            new (2)
            {
                NationalCurrencyCode = "UAH",
                TargetCurrencyCode = "USD",
                Buy = 41.2f,
                Sale = 34f,
                CreatedAt = createdAt   
            },
            new (3)
            {
                NationalCurrencyCode = "UAH",
                TargetCurrencyCode = "PLN",
                Buy = 43f,
                Sale = 43f,
                CreatedAt = createdAt
            },
            new (4)
            {
                NationalCurrencyCode = "USD",
                TargetCurrencyCode = "UAH",
                Buy = 43f,
                Sale = 43f,
                CreatedAt = createdAt
            },
            new (5)
            {
                NationalCurrencyCode = "USD",
                TargetCurrencyCode = "EUR",
                Buy = 32f,
                Sale = 32f,
                CreatedAt = createdAt
            },
            new (6)
            {
                NationalCurrencyCode = "USD",
                TargetCurrencyCode = "PLN",
                Buy = 41f,
                Sale = 43f,
                CreatedAt = createdAt
            },
            new (7)
            {
                NationalCurrencyCode = "EUR",
                TargetCurrencyCode = "USD",
                Buy = 41f,
                Sale = 40f,
                CreatedAt = createdAt
            },
            new (8)
            {
                NationalCurrencyCode = "EUR",
                TargetCurrencyCode = "UAH",
                Buy = 39f,
                Sale = 38f,
                CreatedAt = createdAt
            },
            new (9)
            {
                NationalCurrencyCode = "EUR",
                TargetCurrencyCode = "PLN",
                Buy = 30f,
                Sale = 32f,
                CreatedAt = createdAt
            },
            new (10)
            {
                NationalCurrencyCode = "PLN",
                TargetCurrencyCode = "UAH",
                Buy = 20f,
                Sale = 10f,
                CreatedAt = createdAt
            },
            new (11)
            {
                NationalCurrencyCode = "PLN",
                TargetCurrencyCode = "USD",
                Buy = 7f,
                Sale = 6f,
                CreatedAt = createdAt
            },
            new (12)
            {
                NationalCurrencyCode = "PLN",
                TargetCurrencyCode = "EUR",
                Buy = 3f,
                Sale = 20f,
                CreatedAt = createdAt
            },
        ];
    }
}
