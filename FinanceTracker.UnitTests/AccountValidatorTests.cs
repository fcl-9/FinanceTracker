using FinanceTracker.Api.Model;
using FluentValidation.TestHelper;
using FinanceTracker.Controllers;

public class AccountRequestValidatorTests
{
    private readonly AccountRequestValidator _validator = new();

    [Fact]
    public void Should_Have_Error_When_AccountId_Is_Empty()
    {
        var model = new AccountRequest { AccountId = Guid.Empty };

        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(acc => acc.AccountId)
              .WithErrorMessage("AccountId cannot be null or empty.");
    }

    [Fact]
    public void Should_Have_Error_When_AccountName_Is_Null_Or_Empty()
    {
        var modelWithNullName = new AccountRequest { AccountName = null };
        var modelWithEmptyName = new AccountRequest { AccountName = string.Empty };

        var resultNull = _validator.TestValidate(modelWithNullName);
        resultNull.ShouldHaveValidationErrorFor(acc => acc.AccountName)
                  .WithErrorMessage("AccountName cannot be null or empty.");

        var resultEmpty = _validator.TestValidate(modelWithEmptyName);
        resultEmpty.ShouldHaveValidationErrorFor(acc => acc.AccountName)
                   .WithErrorMessage("AccountName cannot be null or empty.");
    }

    [Fact]
    public void Should_Have_Error_When_AccountProvider_Is_Null_Or_Empty()
    {
        var modelWithNullProvider = new AccountRequest { AccountProvider = null };
        var modelWithEmptyProvider = new AccountRequest { AccountProvider = string.Empty };

        var resultNull = _validator.TestValidate(modelWithNullProvider);
        resultNull.ShouldHaveValidationErrorFor(acc => acc.AccountProvider)
                  .WithErrorMessage("AccountProvider cannot be null or empty.");

        var resultEmpty = _validator.TestValidate(modelWithEmptyProvider);
        resultEmpty.ShouldHaveValidationErrorFor(acc => acc.AccountProvider)
                   .WithErrorMessage("AccountProvider cannot be null or empty.");
    }

    [Fact]
    public void Should_Have_Error_When_AccountType_Is_Null_Or_Empty()
    {
        var modelWithNullType = new AccountRequest { AccountType = null };
        var modelWithEmptyType = new AccountRequest { AccountType = string.Empty };

        var resultNull = _validator.TestValidate(modelWithNullType);
        resultNull.ShouldHaveValidationErrorFor(acc => acc.AccountType)
                  .WithErrorMessage("AccountType cannot be null or empty.");

        var resultEmpty = _validator.TestValidate(modelWithEmptyType);
        resultEmpty.ShouldHaveValidationErrorFor(acc => acc.AccountType)
                   .WithErrorMessage("AccountType cannot be null or empty.");
    }

    [Fact]
    public void Should_Not_Have_Error_When_Model_Is_Valid()
    {
        var validModel = new AccountRequest
        {
            AccountId = Guid.NewGuid(),
            AccountName = "Valid Account",
            AccountProvider = "Valid Provider",
            AccountType = "Valid Type"
        };

        var result = _validator.TestValidate(validModel);
        result.ShouldNotHaveAnyValidationErrors();
    }
}
