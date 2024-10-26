using System.Runtime.Versioning;
using FinanceTracker.Api;
using FinanceTracker.Api.Model;
using FinanceTracker.Infrastructure;
using FinanceTracker.Infrastructure.FinanceTracker.Model;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.Controllers;

[ApiController]
[Route("[controller]")]
public class InvestmentController : ControllerBase
{
    private readonly ILogger<InvestmentController> _logger;
    private readonly IValidator<MonthlyRecordRequest> _monthlyRequestValidator;
    private readonly IMonthlyRecordRepository _monthRepository;

    public InvestmentController(ILogger<InvestmentController> logger,
        IValidator<AccountRequest> accountRequestValidator,
        IValidator<MonthlyRecordRequest> monthlyRequestValidator,
        IAccountRepository accountRepository,
        IMonthlyRecordRepository monthRepository)
    {
        _logger = logger;
        _monthlyRequestValidator = monthlyRequestValidator;
        _monthRepository = monthRepository;
    }

    [HttpPost("CreateInvestment")]
    public async Task<IActionResult> CreateInvestment([FromBody] MonthlyRecordRequest monthlyRecordRequest)
    {
        var validationResult = _monthlyRequestValidator.Validate(monthlyRecordRequest);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        //todo: use automapper
        var investment = new MonthlyRecord()
        {
            Id = monthlyRecordRequest.InvestmentId,
            AccountId = monthlyRecordRequest.AccountId,
            Month = monthlyRecordRequest.Month,
            Value = monthlyRecordRequest.Value,

        };
        await _monthRepository.AddAsync(investment);
        //todo use automapper
        return Created(nameof(GetInvestment), investment);
    }

    [HttpPost("GetInvestment")]
    public async Task<IActionResult> GetInvestment(Guid investmentId)
    {
        if (investmentId == Guid.Empty)
        {
            return BadRequest("InvestmentId cannot be null or empty.");
        }
        var investment = await _monthRepository.GetByIdAsync(investmentId);
        //TODO: use auto mapper
        return Ok(investment);
    }
}