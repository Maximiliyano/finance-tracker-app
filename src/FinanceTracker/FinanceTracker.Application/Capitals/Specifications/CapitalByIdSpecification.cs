using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Application.Capitals.Specifications;

internal sealed class CapitalByIdSpecification
    : BaseSpecification<Capital>
{
    public CapitalByIdSpecification(int id)
        : base(c => c.Id == id)
    {
        Includes =
        [
            c => c.Expenses!,
            c => c.Incomes!,
            c => c.TransfersIn!,
            c => c.TransfersOut!
        ];
    }
}