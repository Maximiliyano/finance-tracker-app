using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Capitals.Specifications;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Capitals.Commands.Update;

internal sealed class UpdateCapitalCommandHandler(ICapitalRepository repository, IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateCapitalCommand>
{
    public async Task<Result> Handle(UpdateCapitalCommand request, CancellationToken cancellationToken)
    {
        var capital = await repository.GetAsync(new CapitalByIdSpecification(request.Id));

        if (capital is null)
        {
            return Result.Failure(DomainErrors.Capital.NotFound);
        }

        var updatedCapital = new Capital(request.Id)
        {
            Name = request.Name ?? capital.Name,
            Balance = request.Balance ?? capital.Balance,
            TotalIncome = capital.TotalIncome,
            TotalExpense = capital.TotalExpense,
            TotalTransferIn = capital.TotalTransferIn,
            TotalTransferOut = capital.TotalTransferOut,
            CreatedAt = capital.CreatedAt,
            CreatedBy = capital.CreatedBy,
            UpdatedAt = capital.UpdatedAt,
            UpdatedBy = capital.UpdatedBy,
            DeletedAt = capital.DeletedAt,
            IsDeleted = capital.IsDeleted,
            Incomes = capital.Incomes,
            Expenses = capital.Expenses,
            TransfersIn = capital.TransfersIn,
            TransfersOut = capital.TransfersOut
        };

        repository.Update(updatedCapital);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}