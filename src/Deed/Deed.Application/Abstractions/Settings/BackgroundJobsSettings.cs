namespace Deed.Application.Abstractions.Settings;

public sealed class BackgroundJobsSettings
{
    public required string CronExchangeSchedule { get; init; }
}
