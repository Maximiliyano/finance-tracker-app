namespace FinanceTracker.Domain.Results;

public sealed record Error
{
    public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Failure);

    private Error(string code, string message, ErrorType type)
    {
        Code = code;
        Message = message;
        Type = type;
    }

    public string Code { get; }

    public string Message { get; }

    public ErrorType Type { get; }

    public static Error Failure(string code, string message)
        => new(code, message, ErrorType.Failure);

    public static Error BadRequest(string code, string message)
        => new(code, message, ErrorType.BadRequest);
}