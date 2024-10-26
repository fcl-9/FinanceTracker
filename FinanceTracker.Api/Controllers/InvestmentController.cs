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
    private readonly IValidator<InvestmentRecordRequest> _investmentRequestValidator;
    private readonly IInvestmentRepository _investmentRepository;
    private readonly IMapper _mapper;

    public InvestmentController(ILogger<InvestmentController> logger,
        IValidator<InvestmentRecordRequest> investmentRequestValidator,
        IInvestmentRepository investmentRepository, IMapper mapper)
    {
        _logger = logger;
        _investmentRequestValidator = investmentRequestValidator;
        _investmentRepository = investmentRepository;
        _mapper = mapper;
    }

    [HttpPost("CreateInvestment")]
    public async Task<IActionResult> CreateInvestment([FromBody] InvestmentRecordRequest investmentRecordRequest)
    {
        var validationResult = _investmentRequestValidator.Validate(investmentRecordRequest);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        var dbModel = _mapper.Map<MonthlyRecord>(investmentRecordRequest);
        await _investmentRepository.AddAsync(dbModel);

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
        var dbModel = await _investmentRepository.GetByIdAsync(investmentId);
        var responseModel = _mapper.Map<InvestmentResponse>(dbModel);
        return Ok(responseModel);
    }
}