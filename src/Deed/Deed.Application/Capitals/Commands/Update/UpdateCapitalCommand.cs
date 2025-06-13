using Deed.Application.Abstractions.Messaging;

namespace Deed.Application.Capitals.Commands.Update;

public sealed record UpdateCapitalCommand(
    int Id,
    string? Name = null,
    float? Balance = null,
    string? Currency = null)
    : ICommand;
