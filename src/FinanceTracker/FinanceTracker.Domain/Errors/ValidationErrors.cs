using FinanceTracker.Domain.Results;

namespace FinanceTracker.Domain.Errors;

public static class ValidationErrors
{
    public static class Capital
    {
        public static Error AlreadyExists
            => Error.Conflict(nameof(AlreadyExists), "The capital was already exists.");
        
        public static Error NotFound
            => Error.NotFound(nameof(NotFound), "The capital was not found.");
    }
    
    public static class Amount
    {
        public static Error AmountMustBeGreaterThanZero
            => Error.BadRequest(nameof(AmountMustBeGreaterThanZero), "Amount must be greater than zero.");
    }
}
