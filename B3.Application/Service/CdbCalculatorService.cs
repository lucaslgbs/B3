using B3.Domain.Dto;
using B3.Domain.Interface.Repository;
using B3.Domain.Interface.Service;
using B3.Domain.Utils;
using FluentValidation;

namespace B3.Application.Service;

public class CdbCalculatorService : ICalculatorService
{
    private readonly IInvestmentTaxRepository _investmentTaxRepository;
    private readonly IValidator<InvestmentCalculationDto> _validator;

    public CdbCalculatorService(IInvestmentTaxRepository investmentTaxRepository
    , IValidator<InvestmentCalculationDto> validator)
    {
        _investmentTaxRepository = investmentTaxRepository;
        _validator = validator;
    }
    
    public async Task<InvestmentProjectionDto> Calculate(InvestmentCalculationDto dto)
    {
        var result = await _validator.ValidateAsync(dto);
        if (!result.IsValid)
            throw new Exception($"{result.Errors[0].PropertyName} {result.Errors[0].ErrorMessage}");
        
        int month = 1;
        double initialInvestment = dto.Value;
        double investmentValue = dto.Value;
        
        while (month <= dto.Months)
        {
            investmentValue = CdbCalculator.Calculate(investmentValue, 1.08, 0.009);
            month++;
        }
        
        var tax = _investmentTaxRepository.GetTax(dto.Months);
        
        return new InvestmentProjectionDto(investmentValue, investmentValue - ((investmentValue - initialInvestment) * tax.Value));
    }
}