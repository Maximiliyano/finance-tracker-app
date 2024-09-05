using FinanceTracker.Api.Extensions;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Results;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.Api.Handlers;

internal sealed class GlobalExceptionHandler
    : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var error = ParseException(exception).First();

        var statusCode = error.Type.GetStatusCode();

        var problemDetails = BuildProblemDetails(statusCode, exception.Message, error);

        httpContext.Response.StatusCode = statusCode;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
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

    private static Error[] ParseException(Exception exception)
        => exception switch
        {
            _ =>[DomainErrors.General.Exception(exception.Message)]
        };
}