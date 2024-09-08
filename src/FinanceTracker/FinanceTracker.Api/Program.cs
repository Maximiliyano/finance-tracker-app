using FinanceTracker.Api;
using FinanceTracker.Api.Endpoints;
using FinanceTracker.Api.Extensions;
using FinanceTracker.Application;
using FinanceTracker.Infrastructure;
using FinanceTracker.Infrastructure.Persistence.Extensions;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;
using AssemblyReference = FinanceTracker.Api.AssemblyReference;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilogDependencies();

builder.Services
    .AddApi()
    .AddApplication()
    .AddInfrastructure();

builder.Services.AddEndpoints(AssemblyReference.Assembly);

var app = builder.Build();

app.MapEndpoints();

app.UseSwaggerDependencies();

app.ApplyMigrations();

app.UseSerilogRequestLogging();

app.UseCorsPolicy();

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.MapHealthChecks("health");

await app.RunAsync();
