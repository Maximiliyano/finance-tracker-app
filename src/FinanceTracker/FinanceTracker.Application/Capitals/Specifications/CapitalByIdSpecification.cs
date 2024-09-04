using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Application.Capitals.Specifications;

internal sealed class CapitalByIdSpecification(int id)
    : BaseSpecification<Capital>(c => c.Id == id);