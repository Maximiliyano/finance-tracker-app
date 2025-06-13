namespace Deed.Application.Capitals.Requests;

public sealed record UpdateCapitalRequest(
    string? Name,
    float? Balance,
    string? Currency);
