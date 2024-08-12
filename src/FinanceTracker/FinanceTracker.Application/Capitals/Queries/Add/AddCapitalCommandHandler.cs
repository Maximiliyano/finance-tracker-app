using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Capitals.Queries.Add;

public sealed class AddCapitalCommandHandler(
    ICapitalRepository repository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<AddCapitalCommand>
{
    public async Task<Result> Handle(AddCapitalCommand request, CancellationToken cancellationToken)
    {
        var capital = BuildCapital(request.Name, request.Balance);

        repository.Add(capital);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }

    private static Capital BuildCapital(string name, float balance)
        => new()
        {
            Name = name,
            Balance = balance,
            TotalIncome = 0,
            TotalExpense = 0,
            TotalTransferIn = 0,
            TotalTransferOut = 0
        };
}