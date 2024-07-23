namespace B3.Domain.Dto;

public record InvestmentProjectionDto(double Total, double Taxes)
{
    public double Total { get; set; } = Total;
    public double Taxes { get; set; } = Taxes;
}