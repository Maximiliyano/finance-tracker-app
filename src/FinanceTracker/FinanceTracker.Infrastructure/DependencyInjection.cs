using FinanceTracker.Application.Abstractions.Data;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Infrastructure.BackgroundJobs.SaveLatestExchange;
using FinanceTracker.Infrastructure.Persistence;
using FinanceTracker.Infrastructure.Persistence.Interceptors;
using FinanceTracker.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Quartz;

namespace FinanceTracker.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbDependencies();

        services.AddRepositories();

        services.AddBackgroundJobs();

        return services;
    }

    private static IServiceCollection AddBackgroundJobs(this IServiceCollection services)
    {
        services.AddQuartz();

        services.AddQuartzHostedService(options
            => options.WaitForJobsToComplete = true);

        services.ConfigureOptions<SaveLatestExchangeJobSetup>();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<ICapitalRepository, CapitalRepository>();

        services.AddTransient<IExpenseRepository, ExpenseRepository>();

        services.AddTransient<IExchangeRepository, ExchangeRepository>();

        services.AddTransient<IIncomeRepository, IncomeRepository>();

        services.AddTransient<ICategoryRepository, CategoryRepository>();

        return services;
    }

    private static IServiceCollection AddDbDependencies(this IServiceCollection services)
    {
        var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

        services.Configure<DatabaseSettings>(configuration.GetSection(nameof(DatabaseSettings)));

        services.AddSingleton<UpdateAuditableEntitiesInterceptor>();

        services.AddDbContext<FinanceTrackerDbContext>((sp, options) =>
        {
            var databaseSettings = sp.GetRequiredService<IConfiguration>().GetConnectionString("Database");
            var auditableInterceptor = sp.GetRequiredService<UpdateAuditableEntitiesInterceptor>();

            options.UseSqlServer(databaseSettings)
                .AddInterceptors(auditableInterceptor);
        });

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<FinanceTrackerDbContext>());
        services.AddScoped<IFinanceTrackerDbContext>(sp => sp.GetRequiredService<FinanceTrackerDbContext>());

        return services;
    }
}
