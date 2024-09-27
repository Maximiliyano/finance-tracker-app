namespace FinanceTracker.Application.Abstractions;

public sealed class BackgroundJobsSettings
{
    public required string CronExchangeSchedule { get; init; }
}
