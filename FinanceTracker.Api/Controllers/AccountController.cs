using FinanceTracker.Api.Model;
using FinanceTracker.Infrastructure;
using FinanceTracker.Infrastructure.FinanceTracker.Model;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly ILogger<AccountController> _logger;
    private readonly IValidator<AccountRequest> _accountRequestValidator;
    private readonly IAccountRepository _accountRepository;

    public AccountController(ILogger<AccountController> logger, IValidator<AccountRequest> accountRequestValidator, IAccountRepository accountRepository)
    {
        _logger = logger;
        _accountRequestValidator = accountRequestValidator;
        _accountRepository = accountRepository;
    }

    [HttpPost("CreateAccount")]
    public async Task<IActionResult> CreateAccount([FromBody] AccountRequest accountRequest)
    {
        var validationResult = _accountRequestValidator.Validate(accountRequest);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        //todo: map to db model automapper
        var dbModel = new Account()
        {
            AccountId = accountRequest.AccountId,
            AccountName = accountRequest.AccountName!,
            AccountProvider = accountRequest.AccountProvider!,
            AccountType = accountRequest.AccountType!
        };
        await _accountRepository.AddAsync(dbModel);
        return Created(nameof(GetAccount), dbModel);
    }

    [HttpGet("GetAccount")]
    public async Task<IActionResult> GetAccount(Guid accountId)
    {
        if (accountId == Guid.Empty)
        {
            return BadRequest("AccountId cannot be null or empty.");
        }
        var account = await _accountRepository.GetByIdAsync(accountId);
        //TODO: map to response model
        return Ok(account);
    }
}