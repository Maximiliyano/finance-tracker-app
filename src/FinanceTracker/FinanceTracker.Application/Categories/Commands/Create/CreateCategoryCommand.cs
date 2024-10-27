using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Application.Categories.Commands.Create;

public sealed record CreateCategoryCommand(
    string Name,
    CategoryType Type,
    float PlannedPeriodAmount,
    PerPeriodType Period)
    : ICommand<int>;
