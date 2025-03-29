using FinanceTracker.Api;
using FinanceTracker.Api.Extensions;
using FinanceTracker.Application;
using FinanceTracker.Infrastructure;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;
using AssemblyReference = FinanceTracker.Api.AssemblyReference;
// TODO https://next.privat24.ua/api/p24/pub/exchangerates/all?xref=bbb96a1785c0641b3684b9fe26a59a7a
// TODO change it on localhost when deploy
var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options => options
    .ListenAnyIP(8080));

builder.Host.UseSerilogDependencies();

builder.Configuration.AddEnvironmentVariables();

builder.Services
    .AddApplication()
    .AddApi()
    .AddInfrastructure();

builder.Services.AddEndpoints(AssemblyReference.Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDependencies();
    app.ApplyMigrations();
}

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
