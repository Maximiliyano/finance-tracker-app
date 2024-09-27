using FinanceTracker.Api;
using FinanceTracker.Api.Extensions;
using FinanceTracker.Application;
using FinanceTracker.Infrastructure;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;
using AssemblyReference = FinanceTracker.Api.AssemblyReference;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilogDependencies();

builder.Services
    .AddApplication()
    .AddApi()
    .AddInfrastructure();

builder.Services.AddEndpoints(AssemblyReference.Assembly);

var app = builder.Build();

/*if (app.Environment.IsDevelopment())
{
}*/

app.UseSwaggerDependencies();

app.ApplyMigrations();

app.MapHealthChecks("health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseRequestContextLogging();

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.UseCorsPolicy();

app.UseHttpsRedirection();

app.MapEndpoints();

await app.RunAsync();
