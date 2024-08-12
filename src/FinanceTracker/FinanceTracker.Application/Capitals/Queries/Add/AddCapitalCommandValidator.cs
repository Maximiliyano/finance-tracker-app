using FinanceTracker.Application.Capitals.Specifications;
using FinanceTracker.Domain.Repositories;
using FluentValidation;

namespace FinanceTracker.Application.Capitals.Queries.Add;

internal sealed class AddCapitalCommandValidator : AbstractValidator<AddCapitalCommand>
{
    public AddCapitalCommandValidator(ICapitalRepository repository)
    {
        RuleFor(c => c.Name)
            .MustAsync(async (name, _) => !await repository
                .AnyAsync(new CapitalByNameSpecification(name)))
            .NotEmpty()
            .MinimumLength(1)
            .MaximumLength(24);
    }
}