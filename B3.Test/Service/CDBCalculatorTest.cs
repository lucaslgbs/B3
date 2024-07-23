using B3.Domain.Utils;
using NUnit.Framework;

namespace B3.Test.Service;

[TestFixture]
public class CDBCalculatorTest
{
    [Test]
    public void CDBCalculateTests()
    {
        var result1 = CDBCalculator.Calculate(1000, 1.08, 0.009);
        Assert.AreEqual(1009.7199999999999, result1);
        
        var result2 = CDBCalculator.Calculate(1, 1.08, 0.009);
        Assert.AreEqual(1.00972, result2);
        
        var result3 = CDBCalculator.Calculate(0.01, 1.08, 0.009);
        Assert.AreEqual(0.010097199999999999, result3);
    }
}