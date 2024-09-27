using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Application.Capitals.Specifications;

internal sealed class CapitalByIdSpecification
    : BaseSpecification<Capital>
{
    public CapitalByIdSpecification(int id)
        : base(c => c.Id == id)
    {
        AddInclude(c => c.Expenses);
        AddInclude(c => c.Incomes);
        AddInclude(c => c.TransfersIn);
        AddInclude(c => c.TransfersOut);
    }
}
