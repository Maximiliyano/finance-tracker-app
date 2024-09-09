using FinanceTracker.Domain.Repositories;
using FinanceTracker.Infrastructure.Persistence;
using FinanceTracker.Infrastructure.Persistence.Interceptors;
using FinanceTracker.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FinanceTracker.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbDependencies();

        services.AddRepositories();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<ICapitalRepository, CapitalRepository>();

        services.AddTransient<IExpenseRepository, ExpenseRepository>();

        services.AddTransient<IIncomeRepository, IncomeRepository>();

        return services;
    }

    private static IServiceCollection AddDbDependencies(this IServiceCollection services)
    {
        var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

        services.Configure<DatabaseSettings>(configuration.GetSection(nameof(DatabaseSettings)));

        services.AddSingleton<UpdateAuditableEntitiesInterceptor>();

        services.AddDbContext<FinanceTrackerDbContext>((sp, options) =>
        {
            var databaseSettings = sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
            var auditableInterceptor = sp.GetRequiredService<UpdateAuditableEntitiesInterceptor>();

            options.UseSqlServer(databaseSettings.Connection)
                .AddInterceptors(auditableInterceptor);
        });

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<FinanceTrackerDbContext>());

        return services;
    }
}
