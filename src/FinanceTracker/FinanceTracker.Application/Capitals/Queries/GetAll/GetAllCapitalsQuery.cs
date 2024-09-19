using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Capitals.Responses;

namespace FinanceTracker.Application.Capitals.Queries.GetAll;

public sealed record GetAllCapitalsQuery : IQuery<IEnumerable<CapitalResponse>>;