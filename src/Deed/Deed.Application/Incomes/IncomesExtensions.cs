using Deed.Application.Incomes.Commands.Create;
using Deed.Application.Incomes.Responses;
using Deed.Domain.Entities;

namespace Deed.Application.Incomes;

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
