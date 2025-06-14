using Deed.Application.Abstractions;
using Deed.Domain.Entities;

namespace Deed.Application.Capitals.Specifications;

internal sealed class CapitalByIdSpecification(int id)
    : BaseSpecification<Capital>(c => c.Id == id);
