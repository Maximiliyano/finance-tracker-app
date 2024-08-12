using FinanceTracker.Domain.Results;

namespace FinanceTracker.Api.Extensions;

internal static class ResultExtensions
{
    public static IResult Process(this Result result)
    {
        return result.IsSuccess
            ? Results.Ok()
            : Results.BadRequest();
    }

    public static IResult Process<TValue>(this Result<TValue> result)
    {
        return result.IsSuccess
            ? Results.Ok(result.Value)
            : Results.BadRequest();
    }
}