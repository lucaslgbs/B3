using B3.Domain.Interface.Repository;
using B3.Domain.Model;

namespace B3.Infra.Repository;

public class InvestmentTaxRepository : IInvestmentTaxRepository
{
    private List<InvestmentTax> _taxes { get; set; } = new List<InvestmentTax>();

    public InvestmentTaxRepository()
    {
        _taxes.Add(new InvestmentTax { Min = 1, Max = 6, Value = 0.225});
        _taxes.Add(new InvestmentTax { Min = 7, Max = 12, Value = 0.2});
        _taxes.Add(new InvestmentTax { Min = 13, Max = 24, Value = 0.175});
        _taxes.Add(new InvestmentTax { Min = 25, Max = 9999, Value = 0.15});
    }
    
    public async Task<InvestmentTax> GetTax(int months)
    {
        return _taxes.FirstOrDefault(x => x.Min <= months && x.Max >= months);
    } 
}