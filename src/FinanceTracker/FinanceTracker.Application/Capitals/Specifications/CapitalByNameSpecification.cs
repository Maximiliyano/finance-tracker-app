using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Application.Capitals.Specifications;

internal sealed class CapitalByNameSpecification(string name)
    : BaseSpecification<Capital>(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));