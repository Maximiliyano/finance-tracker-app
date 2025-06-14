using FinanceTracker.Application.Abstractions.Messaging;
using FinanceTracker.Application.Incomes.Specifications;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Incomes.Commands.Update;

internal sealed class UpdateIncomeCommandHandler(
    IIncomeRepository incomeRepository,
    ICapitalRepository capitalRepository,
    ICategoryRepository categoryRepository,
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

        if (command.Amount.HasValue)
        {
            var difference = (float)(command.Amount - income.Amount);

            income.Capital!.Balance += difference;

            income.Amount = command.Amount.Value;

            capitalRepository.Update(income.Capital!);
        }

        income.Purpose = command.Purpose ?? income.Purpose;
        income.PaymentDate = command.PaymentDate ?? income.PaymentDate;

        if (command.CategoryId.HasValue)
        {
            income.CategoryId = command.CategoryId.Value;

            categoryRepository.Update(income.Category!); // TODO !
        }

        incomeRepository.Update(income);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
