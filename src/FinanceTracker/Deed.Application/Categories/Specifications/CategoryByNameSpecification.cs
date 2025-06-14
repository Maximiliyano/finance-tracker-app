using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Application.Categories.Specifications;

internal sealed class CategoryByNameSpecification(string name)
    : BaseSpecification<Category>(c => StringComparer.CurrentCultureIgnoreCase.Compare(c.Name, name) == 0);
