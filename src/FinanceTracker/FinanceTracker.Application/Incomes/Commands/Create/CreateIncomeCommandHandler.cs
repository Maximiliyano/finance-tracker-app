using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Capitals.Specifications;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Incomes.Commands.Create;

public sealed class CreateIncomeCommandHandler(
    ICapitalRepository capitalRepository,
    IIncomeRepository incomeRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateIncomeCommand, int>
{
    public async Task<Result<int>> Handle(CreateIncomeCommand command, CancellationToken cancellationToken)
    {
        var capital = await capitalRepository.GetAsync(new CapitalByIdSpecification(command.CapitalId));

        if (capital is null)
        {
            return Result.Failure<int>(DomainErrors.General.NotFound);
        }

        var income = command.ToEntity();
        
        capital.Balance += command.Amount;

        incomeRepository.Create(income);
        
        capitalRepository.Update(capital);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return income.Id;
    }
}
