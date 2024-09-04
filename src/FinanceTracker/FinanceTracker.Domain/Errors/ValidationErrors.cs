using FinanceTracker.Domain.Results;

namespace FinanceTracker.Domain.Errors;

public static class ValidationErrors
{
    public static class Capital
    {
        public static Error AlreadyExists
            => Error.BadRequest(nameof(AlreadyExists), "The capital was already exists.");
    }
}
