using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Exchanges.Commands.AddRange;

public sealed class AddExchangesCommandHandler(
    IExchangeRepository repository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<AddExchangesCommand>
{
    public async Task<Result> Handle(AddExchangesCommand request, CancellationToken cancellationToken)
    {
        var exchanges = request.Exchanges.Select(x => new Exchange
        {
            NationalCurrencyCode = x.NationalCurrency,
            TargetCurrencyCode = x.TargetCurrency,
            Buy = x.Buy,
            Sale = x.Sale
        });
        
        repository.AddRange(exchanges);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
