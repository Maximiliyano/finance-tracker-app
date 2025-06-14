using Deed.Application.Abstractions.Messaging;
using Deed.Application.Incomes.Responses;

namespace Deed.Application.Incomes.Queries.GetById;

public sealed record GetIncomeByIdQuery(int Id)
    : IQuery<IncomeResponse>;
