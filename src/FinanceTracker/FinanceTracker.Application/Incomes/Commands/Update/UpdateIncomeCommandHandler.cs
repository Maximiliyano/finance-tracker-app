using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Incomes.Specifications;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Incomes.Commands.Update;

internal sealed class UpdateIncomeCommandHandler(
    IIncomeRepository incomeRepository,
    ICapitalRepository capitalRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateIncomeCommand>
{
    public async Task<Result> Handle(UpdateIncomeCommand command, CancellationToken cancellationToken)
    {
        var income = await incomeRepository.GetAsync(new IncomeByIdSpecification(command.Id));

        if (income is null)
        {
            return Result.Failure(DomainErrors.General.NotFound(nameof(income)));
        }

        if (command.Amount is not null)
        {
            var difference = (float)(command.Amount - income.Amount);

            income.Capital!.Balance += difference;
        }

        income.Amount = command.Amount ?? income.Amount;
        income.Purpose = command.Purpose ?? income.Purpose;
        income.PaymentDate = command.PaymentDate ?? income.PaymentDate;
        income.CategoryId = command.CategoryId ?? income.CategoryId;

        incomeRepository.Update(income);

        capitalRepository.Update(income.Capital!);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
