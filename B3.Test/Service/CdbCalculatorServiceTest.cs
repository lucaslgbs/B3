using B3.Application.Service;
using B3.Application.Validation;
using B3.Domain.Dto;
using B3.Domain.Interface.Repository;
using B3.Domain.Interface.Service;
using B3.Infra.Repository;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace B3.Test.Service;

[TestFixture]
public class CdbCalculatorServiceTest
{
    private ICalculatorService _cdbCalculatorService;

    [SetUp]
    public void Setup()
    {
        var services = new ServiceCollection();
        services.AddScoped<ICalculatorService, CdbCalculatorService>();
        services.AddScoped<IInvestmentTaxRepository, InvestmentTaxRepository>();
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssembly(typeof(InvestmentCalculatorValidator).Assembly);

        var serviceProvider = services.BuildServiceProvider();

        _cdbCalculatorService = serviceProvider.GetService<ICalculatorService>();
    }
    
    [Test]
    public void CdbCalculateTests_Tax6Success()
    {
        var mock = new InvestmentCalculationDto(1000, 6);

        var result = _cdbCalculatorService.Calculate(mock).Result;
        
        Assert.That(result.GrossValue, Is.EqualTo(1059.755677014898));
        Assert.That(result.NetValue, Is.EqualTo(1046.310649686546));
    }
    
    [Test]
    public void CDBCalculateTests_Tax12Success()
    {
        var mock = new InvestmentCalculationDto(1000, 12);

        var result = _cdbCalculatorService.Calculate(mock).Result;
        
        Assert.That(result.GrossValue, Is.EqualTo(1123.0820949653053));
        Assert.That(result.NetValue, Is.EqualTo(1098.4656759722443));
    }
    
    [Test]
    public void CDBCalculateTests_Tax24Success()
    {
        var mock = new InvestmentCalculationDto(1000, 24);

        var result = _cdbCalculatorService.Calculate(mock).Result;
        
        Assert.That(result.GrossValue, Is.EqualTo(1261.3133920316586));
        Assert.That(result.NetValue, Is.EqualTo(1215.5835484261183));
    }
    
    [Test]
    public void CDBCalculateTests_Tax25Success()
    {
        var mock = new InvestmentCalculationDto(1000, 25);

        var result = _cdbCalculatorService.Calculate(mock).Result;
        
        Assert.That(result.GrossValue, Is.EqualTo(1273.5733582022062));
        Assert.That(result.NetValue, Is.EqualTo(1232.5373544718752));
    }
    
    [Test]
    public void CDBCalculateTests_Months1Error()
    {
        var mock = new InvestmentCalculationDto(1000, 1);
        
        var ex = Assert.ThrowsAsync<Exception>(() => _cdbCalculatorService.Calculate(mock));
        
        Assert.That(ex!.Message, Is.EqualTo("Months é inválido."));
    }
    
    [Test]
    public void CDBCalculateTests_Value0Error()
    {
        var mock = new InvestmentCalculationDto(0, 2);
        
        var ex = Assert.ThrowsAsync<Exception>(() => _cdbCalculatorService.Calculate(mock));
        
        Assert.That(ex!.Message, Is.EqualTo("Value é inválido."));
    }
}