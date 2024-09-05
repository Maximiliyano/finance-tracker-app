using FinanceTracker.Api;
using FinanceTracker.Api.Endpoints;
using FinanceTracker.Api.Extensions;
using FinanceTracker.Application;
using FinanceTracker.Infrastructure;
using FinanceTracker.Infrastructure.Persistence.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilogDependencies();

builder.Services
    .AddApi()
    .AddApplication()
    .AddInfrastructure();

var app = builder.Build();

app.UseSwaggerDependencies();

await app.AutoMigrateDatabaseAsync();

app.UseSerilogRequestLogging();

app.UseCorsPolicy();

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.MapHealthChecks("/health");

app.MapCapitalEndpoints();

app.MapIncomesEndpoints();

app.MapExpensesEndpoints();

app.MapExchangeEndpoints();

await app.RunAsync();