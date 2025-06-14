using FinanceTracker.Application.Abstractions.Messaging;

namespace FinanceTracker.Application.Categories.Commands.Delete;

public sealed record DeleteCategoryCommand(
    int Id)
    : ICommand;
