using FinanceTracker.Api.Model;
using FinanceTracker.Infrastructure;
using FinanceTracker.Infrastructure.FinanceTracker.Model;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IValidator<AccountRequest> _accountRequestValidator;
    private readonly IValidator<MonthlyRecordRequest> _monthlyRequestValidator;
    private readonly IAccountRepository _accountRepository;
    private readonly IMonthlyRecordRepository _monthRepository;

    public WeatherForecastController(ILogger<WeatherForecastController> logger,
        IValidator<AccountRequest> accountRequestValidator,
        IValidator<MonthlyRecordRequest> monthlyRequestValidator,
        IAccountRepository accountRepository,
        IMonthlyRecordRepository monthRepository)
    {
        _logger = logger;
        _accountRequestValidator = accountRequestValidator;
        _monthlyRequestValidator = monthlyRequestValidator;
        _accountRepository = accountRepository;
        _monthRepository = monthRepository;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
            .ToArray();
    }

    [HttpPost("CreateAccount")]
    public IActionResult CreateAccount([FromBody] AccountRequest accountRequest)
    {
        var validationResult = _accountRequestValidator.Validate(accountRequest);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var dbModel = new Account()
        {
            AccountId = accountRequest.AccountId,
            AccountName = accountRequest.AccountName!,
            AccountProvider = accountRequest.AccountProvider!,
            AccountType = accountRequest.AccountType!
        };
        _accountRepository.AddAsync(dbModel);
        return Created("GetAccount", dbModel);
    }

    [HttpPost("CreateInvestment")]
    public IActionResult CreateInvestment([FromBody] MonthlyRecordRequest monthlyRecordRequest)
    {
        var validationResult = _monthlyRequestValidator.Validate(monthlyRecordRequest);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        // _monthRepository.AddAsync();
        throw new NotImplementedException();
    }
}