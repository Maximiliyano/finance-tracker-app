using Deed.Application.Abstractions;
using Deed.Domain.Entities;

namespace Deed.Application.Categories.Specifications;

internal sealed class CategoryByNameSpecification(string name)
    : BaseSpecification<Category>(c => StringComparer.CurrentCultureIgnoreCase.Compare(c.Name, name) == 0);
