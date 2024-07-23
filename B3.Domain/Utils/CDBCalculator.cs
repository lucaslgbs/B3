namespace B3.Domain.Utils;

public static class CDBCalculator
{
    public static double Calculate(double investmentValue, double tb, double cdi)
    {
        return investmentValue * (1 + (tb * cdi));
    }
}