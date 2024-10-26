using FinanceTracker.Api.Model;
using FluentValidation;

namespace FinanceTracker.Controllers;

public class AccountRequestValidator : AbstractValidator<AccountRequest>
{
    public AccountRequestValidator()
    {
        RuleFor(acc => acc.AccountId).NotEmpty().WithMessage("AccountId cannot be null or empty.").NotNull().WithMessage("AccountId cannot be null or empty.");
        RuleFor(acc => acc.AccountName).NotEmpty().WithMessage("AccountName cannot be null or empty.").NotNull().WithMessage("AccountName cannot be null or empty.");
        RuleFor(acc => acc.AccountProvider).NotEmpty().WithMessage("AccountProvider cannot be null or empty.").NotNull().WithMessage("AccountProvider cannot be null or empty.");
        RuleFor(acc => acc.AccountType).NotEmpty().WithMessage("AccountType cannot be null or empty.").NotNull().WithMessage("AccountType cannot be null or empty.");
    }
}