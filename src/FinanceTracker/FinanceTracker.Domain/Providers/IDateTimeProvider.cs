namespace FinanceTracker.Domain.Providers;

public interface IDateTimeProvider
{
    DateTimeOffset UtcNow { get; }
}