using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Application.Capitals.Commands.Update;

public sealed record UpdateCapitalCommand(
    int Id,
    string? Name,
    float? Balance,
    string? Currency)
    : ICommand;
