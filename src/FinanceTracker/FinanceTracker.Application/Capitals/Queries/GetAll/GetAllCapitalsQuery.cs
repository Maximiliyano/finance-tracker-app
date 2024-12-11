using FinanceTracker.Application.Abstractions.Messaging;
using FinanceTracker.Application.Capitals.Responses;

namespace FinanceTracker.Application.Capitals.Queries.GetAll;

public sealed record GetAllCapitalsQuery : IQuery<IEnumerable<CapitalResponse>>;