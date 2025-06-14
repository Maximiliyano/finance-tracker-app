using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Application.Categories.Specifications;

internal sealed class CategoryByIdSpecification(int id)
    : BaseSpecification<Category>(c => c.Id == id);
