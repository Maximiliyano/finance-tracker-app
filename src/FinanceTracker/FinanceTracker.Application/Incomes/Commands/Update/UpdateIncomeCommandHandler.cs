using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Incomes.Specifications;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Incomes.Commands.Update;

public sealed class UpdateIncomeCommandHandler(
    IIncomeRepository incomeRepository,
    ICapitalRepository capitalRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateIncomeCommand>
{
    public async Task<Result> Handle(UpdateIncomeCommand request, CancellationToken cancellationToken)
    {
        var income = await incomeRepository.GetAsync(new IncomeByIdSpecification(request.Id));

        if (income is null)
        {
            return Result.Failure(DomainErrors.General.NotFound);
        }

        var difference = request.Amount - income.Amount;
        
        income.Capital!.Balance += difference;

        income.Amount = request.Amount;
        income.Purpose = request.Purpose;
        income.Type = request.Type;

        incomeRepository.Update(income);
        
        capitalRepository.Update(income.Capital);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
