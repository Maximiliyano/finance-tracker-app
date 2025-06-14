using Deed.Application.Abstractions;
using Deed.Domain.Entities;

namespace Deed.Application.Expenses.Specifications;

internal sealed class ExpenseByIdSpecification(int id)
    : BaseSpecification<Expense>(x => x.Id == id);
