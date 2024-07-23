using B3.Domain.Dto;
using B3.Domain.Interface.Service;
using B3.Domain.Utils;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace B3.Api.Controllers;

[Route("api/calculator")]
public class CalculatorController : ControllerBase
{
    private readonly ICalculatorService _cdbCalculatorService;
    private readonly IValidator<InvestmentCalculationDto> _validator;

    public CalculatorController(ICalculatorService cdbCalculatorService
    , IValidator<InvestmentCalculationDto> validator)
    {
        _cdbCalculatorService = cdbCalculatorService;
        _validator = validator;
    }
    
    [HttpPost("cdb/calculate")]
    public async Task<IActionResult> CDB([FromBody] InvestmentCalculationDto request)
    {
        var result = await _validator.ValidateAsync(request);
        if (!result.IsValid)
            return BadRequest(result.Errors);
        return Ok(await _cdbCalculatorService.Calculate(request));
    }
}