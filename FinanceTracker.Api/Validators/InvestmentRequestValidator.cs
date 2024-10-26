using FinanceTracker.Api.Model.Requests;
using FluentValidation;

namespace FinanceTracker.Api.Validators;

public class InvestmentRequestValidator : AbstractValidator<MonthlyRecordRequest>
{
    public InvestmentRequestValidator()
    {
        RuleFor(mi => mi.Month).NotEmpty().NotNull().InclusiveBetween(1, 12).WithMessage("Month must be between 1 and 12.");
        RuleFor(mi => mi.Year).NotEmpty().NotNull().InclusiveBetween(1990, DateTime.Now.Year).WithMessage($"Year must be between 1900 and {DateTime.Now.Year}.");
        RuleFor(mi => mi.Value).NotEmpty().NotNull().GreaterThanOrEqualTo(0).WithMessage("Value must be a non-negative value (zero or greater).");
        RuleFor(mi => mi.AccountId).NotEmpty().WithMessage("AccountId cannot be null or empty.").NotNull().WithMessage("AccountId cannot be null or empty.");
    }
}