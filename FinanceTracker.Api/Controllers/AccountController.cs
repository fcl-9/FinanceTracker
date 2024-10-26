using AutoMapper;
using FinanceTracker.Api.Mapper;
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
    private readonly IMapper _mapper;

    public AccountController(ILogger<AccountController> logger, IValidator<AccountRequest> accountRequestValidator, IAccountRepository accountRepository, IMapper mapper)
    {
        _logger = logger;
        _accountRequestValidator = accountRequestValidator;
        _accountRepository = accountRepository;
        _mapper = mapper;
    }

    [HttpPost("CreateAccount")]
    public async Task<IActionResult> CreateAccount([FromBody] AccountRequest accountRequest)
    {
        var validationResult = _accountRequestValidator.Validate(accountRequest);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var dbModel = _mapper.Map<Account>(accountRequest);
        await _accountRepository.AddAsync(dbModel);

        var responseModel = _mapper.Map<AccountResponse>(dbModel);
        return Created(nameof(GetAccount), responseModel);
    }

    [HttpGet("GetAccount")]
    public async Task<IActionResult> GetAccount(Guid accountId)
    {
        if (accountId == Guid.Empty)
        {
            return BadRequest("AccountId cannot be null or empty.");
        }
        var account = await _accountRepository.GetByIdAsync(accountId);
        var responseModel = _mapper.Map<AccountResponse>(account);
        return Ok(responseModel);
    }
}