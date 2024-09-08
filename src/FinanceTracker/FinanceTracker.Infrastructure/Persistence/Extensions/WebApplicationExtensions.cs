using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceTracker.Infrastructure.Persistence.Extensions;

public static class WebApplicationExtensions
{
    public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();

        var dbContext = serviceScope.ServiceProvider.GetRequiredService<FinanceTrackerDbContext>();

        dbContext.Database.Migrate();

        return app;
    }
}
