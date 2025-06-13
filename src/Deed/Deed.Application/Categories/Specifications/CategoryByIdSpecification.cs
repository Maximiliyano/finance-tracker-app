using Deed.Application.Abstractions;
using Deed.Domain.Entities;

namespace Deed.Application.Categories.Specifications;

internal sealed class CategoryByIdSpecification(int id)
    : BaseSpecification<Category>(c => c.Id == id);
