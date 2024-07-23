using B3.Domain.Model;

namespace B3.Domain.Interface.Repository;

public interface IInvestmentTaxRepository
{
    Task<InvestmentTax> GetTax(int months);
}