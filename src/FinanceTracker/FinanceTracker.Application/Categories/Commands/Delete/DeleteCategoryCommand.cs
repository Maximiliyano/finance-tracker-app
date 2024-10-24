using FinanceTracker.Application.Abstractions;

namespace FinanceTracker.Application.Categories.Commands.Delete;

public sealed record DeleteCategoryCommand(
    int Id)
    : ICommand;
