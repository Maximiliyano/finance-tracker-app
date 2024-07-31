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

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDependencies();

    await app.AutoMigrateDatabaseAsync();
}

app.UseSerilogRequestLogging();

app.UseCorsPolicy();

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.MapAccountEndpoints();

app.MapExchangeEndpoints();

await app.RunAsync();