using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Incomes.Responses;
using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Application.Incomes.Queries.GetById;

public sealed record GetIncomeByIdQuery(int Id) : IQuery<IEnumerable<IncomeResponse>>;