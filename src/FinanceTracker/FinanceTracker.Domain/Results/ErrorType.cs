namespace FinanceTracker.Domain.Results;

public enum ErrorType
{
    Failure = 0,
    Validation = 1,
    BadRequest = 2,
    NotFound = 3,
}