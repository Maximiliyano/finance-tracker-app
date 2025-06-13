using Deed.Application.Abstractions;
using Deed.Domain.Entities;

namespace Deed.Application.Capitals.Specifications;

internal sealed class CapitalByNameSpecification(string name)
    : BaseSpecification<Capital>(
        c => StringComparer.CurrentCultureIgnoreCase.Compare(c.Name, name) == 0);
