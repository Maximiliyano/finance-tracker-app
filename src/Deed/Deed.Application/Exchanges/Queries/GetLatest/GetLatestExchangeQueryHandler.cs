using Deed.Application.Abstractions.Messaging;
using Deed.Application.Exchanges.Responses;
using Deed.Application.Exchanges.Service;
using Deed.Domain.Entities;
using Deed.Domain.Providers;
using Deed.Domain.Repositories;
using Deed.Domain.Results;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Deed.Application.Exchanges.Queries.GetLatest;

public sealed class GetLatestExchangeQueryHandler(
    IExchangeRepository repository,
    IMemoryCache memoryCache)
    : IQueryHandler<GetLatestExchangeQuery, IEnumerable<ExchangeResponse>>
{
    public async Task<Result<IEnumerable<ExchangeResponse>>> Handle(GetLatestExchangeQuery query, CancellationToken cancellationToken)
    {
        if (!memoryCache.TryGetValue(nameof(Exchanges), out IEnumerable<ExchangeResponse> cachedExchanges))
        {
            var actualExchanges = (await repository.GetAllAsync()).ToResponses();

            memoryCache.Set<IEnumerable<ExchangeResponse>>(nameof(Exchanges), actualExchanges, TimeSpan.FromHours(3));

            return Result.Success(actualExchanges);
        }

        return Result.Success(cachedExchanges!);
    }
}
