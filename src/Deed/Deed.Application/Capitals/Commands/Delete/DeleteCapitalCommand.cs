using Deed.Application.Abstractions.Messaging;

namespace Deed.Application.Capitals.Commands.Delete;

public sealed record DeleteCapitalCommand(
    int Id)
    : ICommand;
