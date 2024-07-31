using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceTracker.Infrastructure.Persistence.Extensions;

public static class WebApplicationExtensions
{
    public static async Task<IApplicationBuilder> AutoMigrateDatabaseAsync(this IApplicationBuilder app)
    {
        await using var serviceScope = app.ApplicationServices.CreateAsyncScope();

        var dbContext = serviceScope.ServiceProvider.GetRequiredService<FinanceTrackerDbContext>();

        await dbContext.Database.MigrateAsync();

        return app;
    }
}