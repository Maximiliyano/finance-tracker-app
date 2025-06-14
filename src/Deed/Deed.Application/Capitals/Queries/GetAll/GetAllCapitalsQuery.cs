using Deed.Application.Abstractions.Messaging;
using Deed.Application.Capitals.Responses;

namespace Deed.Application.Capitals.Queries.GetAll;

public sealed record GetAllCapitalsQuery : IQuery<IEnumerable<CapitalResponse>>;