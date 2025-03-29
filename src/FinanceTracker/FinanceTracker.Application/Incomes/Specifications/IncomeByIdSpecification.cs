using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Application.Incomes.Specifications;

internal sealed class IncomeByIdSpecification
    : BaseSpecification<Income>
{
    public IncomeByIdSpecification(int id)
        : base(i => i.Id == id)
    {
    }
}
