namespace B3.Domain.Dto;

public record InvestmentProjectionDto(double GrossValue, double NetValue)
{
    public double GrossValue { get; set; } = GrossValue;
    public double NetValue { get; set; } = NetValue;
}