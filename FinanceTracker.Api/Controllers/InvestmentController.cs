using AutoMapper;
using FinanceTracker.Api.Infrastructure;
using FinanceTracker.Api.Model;
using FinanceTracker.Api.Model.Database;
using FinanceTracker.Api.Model.Requests;
using FinanceTracker.Api.Model.Response;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class InvestmentController : ControllerBase
{
    private readonly ILogger<InvestmentController> _logger;
    private readonly IValidator<MonthlyRecordRequest> _monthlyRequestValidator;
    private readonly IMonthlyRecordRepository _monthRepository;
    private readonly IMapper _mapper;

    public InvestmentController(ILogger<InvestmentController> logger,
        IValidator<MonthlyRecordRequest> monthlyRequestValidator,
        IMonthlyRecordRepository monthRepository, IMapper mapper)
    {
        _logger = logger;
        _monthlyRequestValidator = monthlyRequestValidator;
        _monthRepository = monthRepository;
        _mapper = mapper;
    }

    [HttpPost("CreateInvestment")]
    public async Task<IActionResult> CreateInvestment([FromBody] MonthlyRecordRequest monthlyRecordRequest)
    {
        var validationResult = _monthlyRequestValidator.Validate(monthlyRecordRequest);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        var dbModel = _mapper.Map<MonthlyRecord>(monthlyRecordRequest);
        await _monthRepository.AddAsync(dbModel);

        var responseModel = _mapper.Map<InvestmentResponse>(dbModel);
        return Created(nameof(GetInvestment), responseModel);
    }

    [HttpGet("GetInvestment")]
    public async Task<IActionResult> GetInvestment(Guid investmentId)
    {
        if (investmentId == Guid.Empty)
        {
            return BadRequest("InvestmentId cannot be null or empty.");
        }
        var dbModel = await _monthRepository.GetByIdAsync(investmentId);
        var responseModel = _mapper.Map<InvestmentResponse>(dbModel);
        return Ok(responseModel);
    }
}