using B3.Domain.Dto;
using FluentValidation;

namespace B3.Application.Validation;

public class InvestmentCalculatorValidator : AbstractValidator<InvestmentCalculationDto> 
{
    public InvestmentCalculatorValidator() 
    {
        RuleFor(x => x.Months).NotNull().WithMessage("é obrigatório.").WithName("Meses");
        RuleFor(x => x.Months).GreaterThanOrEqualTo(1).WithMessage("é inválido.").WithName("Meses");
        RuleFor(x => x.Value).NotNull().WithMessage("é obrigatório.").WithName("Valor");
        RuleFor(x => x.Value).GreaterThan(0).WithMessage("é inválido.").WithName("Valor");
    }
}