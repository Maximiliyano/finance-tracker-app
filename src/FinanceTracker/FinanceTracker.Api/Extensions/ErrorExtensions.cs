using FinanceTracker.Domain.Results;

namespace FinanceTracker.Api.Extensions;

internal static class ErrorExtensions
{
    internal static int GetStatusCode(this ErrorType type)
        => type switch
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.BadRequest => StatusCodes.Status400BadRequest,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };
}