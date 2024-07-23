using B3.Domain.Dto;
using B3.Domain.Interface.Repository;
using B3.Domain.Interface.Service;
using B3.Domain.Utils;
using FluentValidation;

namespace B3.Application.Service;

public class CDBCalculatorService : ICalculatorService
{
    private readonly IInvestmentTaxRepository _investmentTaxRepository;

    public CDBCalculatorService(IInvestmentTaxRepository investmentTaxRepository)
    {
        _investmentTaxRepository = investmentTaxRepository;
    }
    
    public async Task<InvestmentProjectionDto> Calculate(InvestmentCalculationDto dto)
    {
        int month = 1;
        double initialInvestment = dto.Value;
        double investmentValue = dto.Value;
        
        while (month <= dto.Months)
        {
            investmentValue = CDBCalculator.Calculate(investmentValue, 1.08, 0.009);
            month++;
        }
        
        var tax = await _investmentTaxRepository.GetTax(dto.Months);
        
        return new InvestmentProjectionDto(investmentValue, (investmentValue - initialInvestment) * tax.Value);
    }
}