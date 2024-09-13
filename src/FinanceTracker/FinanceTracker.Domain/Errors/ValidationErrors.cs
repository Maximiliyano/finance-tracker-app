using FinanceTracker.Domain.Results;

namespace FinanceTracker.Domain.Errors;

public static class ValidationErrors
{
    public static class Capital
    {
        public static Error AlreadyExists
            => Error.Conflict(nameof(AlreadyExists), "The capital was already exists.");
    }
}
