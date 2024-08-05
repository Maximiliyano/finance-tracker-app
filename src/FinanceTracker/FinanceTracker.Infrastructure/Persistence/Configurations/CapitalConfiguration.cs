using Bogus;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Infrastructure.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTracker.Infrastructure.Persistence.Configurations;

internal sealed class CapitalConfiguration : IEntityTypeConfiguration<Capital>
{
    public void Configure(EntityTypeBuilder<Capital> builder)
    {
        builder.HasKey(a => a.Id);

        builder.ToTable(TableConfigurationConstrants.Capitals);

        builder.HasData(GenerateFakeCapitals());
    }

    private static IEnumerable<Capital> GenerateFakeCapitals(int count = 10)
    {
        var id = 1;
        var fakeCapitals = new Faker<Capital>()
            .CustomInstantiator(f => new Capital(id++)
            {
                Name = f.Finance.AccountName(),
                Balance = (float)f.Finance.Amount(),
                TotalIncome = (float)f.Finance.Amount(),
                TotalExpense = (float)f.Finance.Amount(),
                TotalTransferIn = (float)f.Finance.Amount(),
                TotalTransferOut = (float)f.Finance.Amount(),
            })
            .Generate(count);

        if (fakeCapitals is null)
        {
            return Enumerable.Empty<Capital>();
        }

        return fakeCapitals;
    }
}