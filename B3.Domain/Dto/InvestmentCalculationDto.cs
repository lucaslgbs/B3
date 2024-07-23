using System.ComponentModel;

namespace B3.Domain.Dto;

public record InvestmentCalculationDto
{
    public InvestmentCalculationDto()
    {
        
    }

    public InvestmentCalculationDto(double value, int months)
    {
        this.Value = value;
        this.Months = months;
    }
    
    [DisplayName("Valor do investimento")]
    public double Value { get; set; }
    [DisplayName("Meses")]
    public int Months { get; set; }
}