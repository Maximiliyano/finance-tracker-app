using FinanceTracker.Domain.Results;

namespace FinanceTracker.Domain.Errors;

public static class DomainErrors
{
    public static class General
    {
        public static Error Exception(string message)
            => Error.Failure(nameof(Exception), $"The exception occured with message: {message}");
    }

    public static class Exchange
    {
        public static Error HttpExecution
            => Error.Failure(nameof(HttpExecution), "The http request execution was failed.");

        public static Error Serialization
            => Error.Failure(nameof(Serialization), "The content execution into exchange was failed.");
    }

    public static class Capital
    {
        public static Error NotFound
            => Error.NotFound(nameof(NotFound), "The capital was not found.");
    }
}