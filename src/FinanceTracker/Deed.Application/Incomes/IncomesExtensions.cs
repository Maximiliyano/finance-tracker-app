using FinanceTracker.Application.Incomes.Commands.Create;
using FinanceTracker.Application.Incomes.Responses;
using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Application.Incomes;

internal static class IncomesExtensions
{
    internal static IncomeResponse ToResponse(this Income entity)
        => new(
            entity.Id,
            entity.CategoryId,
            entity.Amount,
            entity.Purpose,
            entity.CreatedAt,
            entity.CapitalId);

    internal static IEnumerable<IncomeResponse> ToResponses(this IEnumerable<Income> entities)
        => entities.Select(e => e.ToResponse());

    internal static Income ToEntity(this CreateIncomeCommand command)
        => new()
        {
            Amount = command.Amount,
            Purpose = command.Purpose,
            CategoryId = command.CategoryId,
            CapitalId = command.CapitalId,
            PaymentDate = command.PaymentDate
        };
}
