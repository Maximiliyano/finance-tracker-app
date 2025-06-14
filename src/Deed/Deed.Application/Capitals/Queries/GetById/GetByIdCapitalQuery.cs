using Deed.Application.Abstractions.Messaging;
using Deed.Application.Capitals.Responses;

namespace Deed.Application.Capitals.Queries.GetById;

public sealed record GetByIdCapitalQuery(
    int Id)
    : IQuery<CapitalResponse>;
