using B3.Domain.Model;

namespace B3.Domain.Interface.Repository;

public interface IInvestmentTaxRepository
{
    InvestmentTax GetTax(int months);
}