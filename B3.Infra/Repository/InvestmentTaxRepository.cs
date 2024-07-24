using B3.Domain.Interface.Repository;
using B3.Domain.Model;

namespace B3.Infra.Repository;

public class InvestmentTaxRepository : IInvestmentTaxRepository
{
    private List<InvestmentTax> Taxes { get; set; } = new List<InvestmentTax>();

    public InvestmentTaxRepository()
    {
        Taxes.Add(new InvestmentTax { Min = 1, Max = 6, Value = 0.225});
        Taxes.Add(new InvestmentTax { Min = 7, Max = 12, Value = 0.2});
        Taxes.Add(new InvestmentTax { Min = 13, Max = 24, Value = 0.175});
        Taxes.Add(new InvestmentTax { Min = 25, Max = 9999, Value = 0.15});
    }
    
    public InvestmentTax GetTax(int months)
    {
        return Taxes.First(x => x.Min <= months && x.Max >= months);
    } 
}