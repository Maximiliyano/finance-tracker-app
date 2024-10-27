using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Capitals.Responses;

namespace FinanceTracker.Application.Capitals.Queries.GetById;

public sealed record GetByIdCapitalQuery(
    int Id)
    : IQuery<CapitalResponse>;
