using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Results;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.Api.Handlers;

internal sealed class GlobalExceptionHandler
    : IExceptionHandler
{
    public ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        /*const string exceptionOccured = "Exception occured";

        LoggerMessage.Define(
            LogLevel.Error,
            new EventId(1, exception.Message),
            exceptionOccured);

        var error = ParseException(exception);

        var statusCode = ParseErrorType(error.Type);

        var problemDetails = BuildProblemDetails(statusCode, exception.Message, error);

        httpContext.Response.StatusCode = statusCode;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;*/
        throw new NotImplementedException();
    }

    private static ProblemDetails BuildProblemDetails(int statusCode, string title, Error error)
        => new()
        {
            Type = nameof(ProblemDetails),
            Title = title,
            Status = statusCode,
            Extensions = new Dictionary<string, object?>
            {
                { nameof(error), error }
            }
        };

    private static Error ParseException(Exception exception)
        => exception switch
        {
            _ => DomainErrors.General.Exception(exception.Message)
        };

    private static int ParseErrorType(ErrorType type)
        => type switch
        {
            ErrorType.BadRequest => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };
}