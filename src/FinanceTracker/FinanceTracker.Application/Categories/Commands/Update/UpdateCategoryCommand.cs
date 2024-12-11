using FinanceTracker.Application.Abstractions.Messaging;
using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Application.Categories.Commands.Update;

public sealed record UpdateCategoryCommand(
    int Id,
    string? Name = null,
    float? PlannedPeriodAmount = null,
    PerPeriodType? Period = null,
    CategoryType? Type = null)
    : ICommand;
