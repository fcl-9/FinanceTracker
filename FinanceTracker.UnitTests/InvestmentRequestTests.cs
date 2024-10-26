using FinanceTracker.Api.Model;
using FinanceTracker.Controllers;
using FluentValidation.TestHelper;

namespace FinanceTracker.UnitTests
{
    public class InvestmentRequestValidatorTests
    {
        private readonly InvestmentRequestValidator _validator = new();

        [Fact]
        public void Should_Have_Error_When_Month_Is_Invalid()
        {
            var requestWithInvalidMonth = new MonthlyRecordRequest { Month = 13 }; // Invalid month

            var result = _validator.TestValidate(requestWithInvalidMonth);
            result.ShouldHaveValidationErrorFor(x => x.Month)
                  .WithErrorMessage("Month must be between 1 and 12.");
        }

        [Fact]
        public void Should_Have_Error_When_Month_Is_Empty()
        {
            var requestWithEmptyMonth = new MonthlyRecordRequest { Month = 0 }; // Empty month (invalid)

            var result = _validator.TestValidate(requestWithEmptyMonth);
            result.ShouldHaveValidationErrorFor(x => x.Month)
                  .WithErrorMessage("Month must be between 1 and 12.");
        }

        [Fact]
        public void Should_Have_Error_When_Year_Is_Invalid()
        {
            var requestWithInvalidYear = new MonthlyRecordRequest { Year = 1989 }; // Invalid year (too low)

            var result = _validator.TestValidate(requestWithInvalidYear);
            result.ShouldHaveValidationErrorFor(x => x.Year)
                  .WithErrorMessage($"Year must be between 1900 and {DateTime.Now.Year}.");
        }

        [Fact]
        public void Should_Have_Error_When_Year_Is_Future()
        {
            var requestWithFutureYear = new MonthlyRecordRequest { Year = DateTime.Now.Year + 1 }; // Future year (invalid)

            var result = _validator.TestValidate(requestWithFutureYear);
            result.ShouldHaveValidationErrorFor(x => x.Year)
                  .WithErrorMessage($"Year must be between 1900 and {DateTime.Now.Year}.");
        }

        [Fact]
        public void Should_Have_Error_When_Value_Is_Negative()
        {
            var requestWithNegativeValue = new MonthlyRecordRequest { Value = -100.00m }; // Negative value

            var result = _validator.TestValidate(requestWithNegativeValue);
            result.ShouldHaveValidationErrorFor(x => x.Value)
                  .WithErrorMessage("Value must be a non-negative value (zero or greater).");
        }

        [Fact]
        public void Should_Not_Have_Error_When_Valid_Month_Year_And_Value()
        {
            var validRequest = new MonthlyRecordRequest
            {
                Month = 5,
                Year = DateTime.Now.Year,
                Value = 1000.50m,
                AccountId = Guid.NewGuid()
            };

            var result = _validator.TestValidate(validRequest);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Should_Have_Error_When_AccountId_Is_Empty()
        {
            var validRequest = new MonthlyRecordRequest
            {
                Month = 5,
                Year = DateTime.Now.Year,
                Value = 1000.50m,
                AccountId = Guid.Empty
            };

            var result = _validator.TestValidate(validRequest);
            result.ShouldHaveValidationErrorFor(mi => mi.AccountId)
                .WithErrorMessage("AccountId cannot be null or empty.");
        }
    }
}
