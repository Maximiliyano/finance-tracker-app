using FinanceTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Api.Extensions;

internal static class MigrationExtensions
{
    public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();

        var dbContext = serviceScope.ServiceProvider.GetRequiredService<FinanceTrackerDbContext>();

        if (!dbContext.Database.EnsureCreated())
        {
            dbContext.Database.Migrate();
        }

        return app;
    }
}
