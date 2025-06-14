using Deed.Application.Abstractions.Messaging;
using Deed.Domain.Enums;

namespace Deed.Application.Categories.Commands.Create;

public sealed record CreateCategoryCommand(
    string Name,
    CategoryType Type,
    float PlannedPeriodAmount,
    PerPeriodType Period)
    : ICommand<int>;
