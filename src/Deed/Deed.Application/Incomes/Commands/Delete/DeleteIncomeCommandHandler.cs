using Deed.Application.Abstractions.Messaging;
using Deed.Application.Incomes.Specifications;
using Deed.Domain.Errors;
using Deed.Domain.Repositories;
using Deed.Domain.Results;

namespace Deed.Application.Incomes.Commands.Delete;

internal sealed class DeleteIncomeCommandHandler(
    IIncomeRepository incomeRepository,
    ICapitalRepository capitalRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteIncomeCommand>
{
    public async Task<Result> Handle(DeleteIncomeCommand command, CancellationToken cancellationToken)
    {
        var income = await incomeRepository.GetAsync(new IncomeByIdSpecification(command.Id));

        if (income is null)
        {
            return Result.Failure(DomainErrors.General.NotFound(nameof(income)));
        }

        income.Capital!.Balance -= income.Amount;

        capitalRepository.Update(income.Capital);

        incomeRepository.Delete(income);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
