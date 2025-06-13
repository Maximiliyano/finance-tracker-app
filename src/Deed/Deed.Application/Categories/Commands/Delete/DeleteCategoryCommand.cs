using Deed.Application.Abstractions.Messaging;

namespace Deed.Application.Categories.Commands.Delete;

public sealed record DeleteCategoryCommand(
    int Id)
    : ICommand;
