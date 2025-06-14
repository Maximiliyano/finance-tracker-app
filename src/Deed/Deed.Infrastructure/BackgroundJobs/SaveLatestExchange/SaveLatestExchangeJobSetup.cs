using Deed.Application.Abstractions.Settings;
using Microsoft.Extensions.Options;
using Quartz;

namespace Deed.Infrastructure.BackgroundJobs.SaveLatestExchange;

public sealed class SaveLatestExchangeJobSetup(
    IOptions<BackgroundJobsSettings> settings)
    : IConfigureOptions<QuartzOptions>
{
    public void Configure(QuartzOptions options)
    {
        var jobKey = JobKey.Create(nameof(SaveLatestExchangeJob));

        options
            .AddJob<SaveLatestExchangeJob>(jobBuilder => jobBuilder
                .WithIdentity(jobKey))
            .AddTrigger(trigger => trigger
                .ForJob(jobKey)
                .WithCronSchedule(settings.Value.CronExchangeSchedule));
    }
}
