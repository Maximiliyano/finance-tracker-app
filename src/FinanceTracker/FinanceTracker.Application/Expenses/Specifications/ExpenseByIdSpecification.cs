using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Application.Expenses.Specifications;

internal sealed class ExpenseByIdSpecification : BaseSpecification<Expense>
{
    public ExpenseByIdSpecification(int id)
        : base(x => x.Id == id)
    {
        AddInclude(e => e.Capital);
        AddInclude(e => e.Category);
    }
}
