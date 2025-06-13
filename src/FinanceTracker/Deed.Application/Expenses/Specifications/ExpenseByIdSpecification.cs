using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Application.Expenses.Specifications;

internal sealed class ExpenseByIdSpecification(int id)
    : BaseSpecification<Expense>(x => x.Id == id);
