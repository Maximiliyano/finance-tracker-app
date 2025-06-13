using FinanceTracker.Domain.Constants;
using FinanceTracker.Domain.Results;
using FluentValidation;

namespace FinanceTracker.Application.Abstractions;

public static class FluentValidationExtensions
{
    public static IRuleBuilderOptions<T, TProperty> WithError<T, TProperty>(
        this IRuleBuilderOptions<T, TProperty> ruleBuilder, Error error)
    {
        if (error is null)
        {
            throw new ArgumentNullException(nameof(error), ValidationConstants.ErrorIsRequired);
        }

        return ruleBuilder
            .WithErrorCode(error.Code)
            .WithMessage(error.Message);
    }
}