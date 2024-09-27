using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Incomes.Specifications;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Incomes.Commands.Delete;

public sealed class DeleteIncomeCommandHandler(
    IIncomeRepository incomeRepository,
    ICapitalRepository capitalRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteIncomeCommand>
{
    public async Task<Result> Handle(DeleteIncomeCommand request, CancellationToken cancellationToken)
    {
        var income = await incomeRepository.GetAsync(new IncomeByIdSpecification(request.Id));

        if (income is null)
        {
            return Result.Failure(DomainErrors.General.NotFound);
        }

        income.Capital!.Balance -= income.Amount;
        
        capitalRepository.Update(income.Capital);
        
        incomeRepository.Delete(income);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
