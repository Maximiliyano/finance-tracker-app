using FinanceTracker.Api.Extensions;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Results;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.Api.Infrastructure;

internal sealed class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        logger.LogError(exception, "Unhandled exception occurred");
        
        var errors = ParseException(exception);
        
        var statusCode = errors[0].Type.GetStatusCode();
        
        var problemDetails = BuildProblemDetails(statusCode, exception.Message, errors);

        httpContext.Response.StatusCode = problemDetails.Status!.Value;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }

    private static ProblemDetails BuildProblemDetails(int statusCode, string title, Error[] errors)
        => new()
        {
            Type = nameof(ProblemDetails),
            Title = title,
            Status = statusCode,
            Extensions = new Dictionary<string, object?>
            {
                { nameof(errors), errors }
            }
        };

    private static Error[] ParseException(Exception exception)
        => exception switch
        {
            _ =>[DomainErrors.General.Exception(exception.Message)]
        };
}
