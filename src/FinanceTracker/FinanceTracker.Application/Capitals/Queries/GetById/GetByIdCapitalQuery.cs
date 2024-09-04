using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Application.Capitals.Queries.GetById;

public sealed record GetByIdCapitalQuery(int Id) : IQuery<Capital>;