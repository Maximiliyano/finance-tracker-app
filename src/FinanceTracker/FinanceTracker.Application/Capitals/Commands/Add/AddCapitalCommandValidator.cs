using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Capitals.Specifications;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Repositories;
using FluentValidation;

namespace FinanceTracker.Application.Capitals.Commands.Add;

internal sealed class AddCapitalCommandValidator : AbstractValidator<AddCapitalCommand>
{
    public AddCapitalCommandValidator(ICapitalRepository repository)
    {
        RuleFor(c => c.Name)
            .MustAsync(async (name, _) => !await repository
                .AnyAsync(new CapitalByNameSpecification(name)))
            .WithError(ValidationErrors.Capital.AlreadyExists)
            .NotEmpty();
    }
}