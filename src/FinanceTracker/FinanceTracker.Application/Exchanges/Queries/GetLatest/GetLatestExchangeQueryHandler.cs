using FinanceTracker.Application.Abstractions.Messaging;
using FinanceTracker.Application.Exchanges.Responses;
using FinanceTracker.Application.Exchanges.Service;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Providers;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Exchanges.Queries.GetLatest;

public sealed class GetLatestExchangeQueryHandler(
    IDateTimeProvider dateTimeProvider,
    IExchangeHttpService service,
    IExchangeRepository repository,
    IUnitOfWork unitOfWork)
    : IQueryHandler<GetLatestExchangeQuery, IEnumerable<ExchangeResponse>>
{
    public async Task<Result<IEnumerable<ExchangeResponse>>> Handle(GetLatestExchangeQuery query, CancellationToken cancellationToken)
    {
        var actualExchanges = (await repository.GetAllAsync()).ToList();

        if (actualExchanges.TrueForAll(x => x.CreatedAt.Date == dateTimeProvider.UtcNow.Date))
        {
            return Result.Success(actualExchanges.ToResponses());
        }
        
        // TODO execute different exchanges and concat in oen
        var newExchangesResult = await service.GetCurrencyAsync(); 
        
        if (!newExchangesResult.IsSuccess)
        {
            return Result.Failure<IEnumerable<ExchangeResponse>>(newExchangesResult.Errors);
        }
        
        var newExchanges = newExchangesResult.Value.ToList();
        var entitiesForUpdate = new List<Exchange>();
        
        // TODO assign newExchanges to existing ids
        foreach (var newExchange in newExchanges)
        {
            var actualExchange = actualExchanges.Find(x =>
                string.Equals(x.NationalCurrencyCode, newExchange.NationalCurrencyCode, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.TargetCurrencyCode, newExchange.TargetCurrencyCode, StringComparison.OrdinalIgnoreCase));

            if (actualExchange is null)
            {
                continue;
            }

            actualExchange.Buy = newExchange.Buy; // TODO finish
            actualExchange.Sale = newExchange.Sale;
            
            entitiesForUpdate.Add(actualExchange);
        }
        
        repository.UpdateRange(entitiesForUpdate);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(actualExchanges.Where(x => x.NationalCurrencyCode == "UAH").ToResponses());
    }
}
