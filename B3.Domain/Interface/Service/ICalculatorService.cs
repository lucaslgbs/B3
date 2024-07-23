using B3.Domain.Dto;

namespace B3.Domain.Interface.Service;

public interface ICalculatorService
{
    Task<InvestmentProjectionDto> Calculate(InvestmentCalculationDto dto);
}