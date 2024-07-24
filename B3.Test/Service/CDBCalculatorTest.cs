using B3.Domain.Utils;
using NUnit.Framework;

namespace B3.Test.Service;

[TestFixture]
public class CDBCalculatorTest
{
    [Test]
    public void CDBCalculateTests()
    {
        var result1 = CdbCalculator.Calculate(1000, 1.08, 0.009);
        Assert.That(result1, Is.EqualTo(1009.7199999999999));
        
        var result2 = CdbCalculator.Calculate(1, 1.08, 0.009);
        Assert.That(result2, Is.EqualTo(1.00972));
        
        var result3 = CdbCalculator.Calculate(0.01, 1.08, 0.009);
        Assert.That(result3, Is.EqualTo(0.010097199999999999));
    }
}