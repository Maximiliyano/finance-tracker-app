using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Capitals.Responses;
using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Application.Capitals.Queries.GetAll;

public sealed record GetAllCapitalsQuery : IQuery<IEnumerable<CapitalResponse>>;