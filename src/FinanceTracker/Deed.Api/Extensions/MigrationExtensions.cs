using Deed.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Deed.Api.Extensions;

internal static class MigrationExtensions
{
    public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();

        var dbContext = serviceScope.ServiceProvider.GetRequiredService<FinanceTrackerDbContext>();

        dbContext.Database.Migrate();

        return app;
    }
}
