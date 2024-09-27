using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Exchanges.Queries.GetLatest;
using FinanceTracker.Domain.Enums;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Results;
using MediatR;

namespace FinanceTracker.Application.Exchanges.Commands.ExchangeCurrency;

public sealed class ExchangeCurrencyCommandHandler(ISender sender)
    : ICommandHandler<ExchangeCurrencyCommand, float>
{
    public async Task<Result<float>> Handle(ExchangeCurrencyCommand request, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetLatestExchangeQuery(), cancellationToken);

        if (!result.IsSuccess)
        {
            return Result.Failure<float>(result.Errors);
        }

        var currencyExchange = result.Value
            .FirstOrDefault(e => e.TargetCurrency == request.Currency.ToString());

        if (currencyExchange is null)
        {
            return Result.Failure<float>(DomainErrors.Exchange.TargetCurrencyUnavailable);
        }

        return request.Operation switch
        {
            ExchangeOperationType.Buy => request.Amount * currencyExchange.Buy,
            ExchangeOperationType.Sale => request.Amount * currencyExchange.Sale,
            _ => Result.Failure<float>(DomainErrors.Exchange.InvalidOperation)
        };
    }
}
