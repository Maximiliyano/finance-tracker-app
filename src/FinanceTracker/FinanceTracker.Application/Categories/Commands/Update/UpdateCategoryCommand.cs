using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Application.Categories.Commands.Update;

public sealed record UpdateCategoryCommand(
    int Id,
    string? Name,
    float? PlannedPeriodAmount,
    PerPeriodType? Period,
    CategoryType? Type)
    : ICommand;
