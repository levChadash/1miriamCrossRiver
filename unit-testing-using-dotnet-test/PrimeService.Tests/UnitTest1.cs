namespace PrimeService.Tests;

public class UnitTest1
{
    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    public void IsPrime_ValuesLessThan2_ReturnFalse(int value)
    {
        var result = _primeService.IsPrime(value);

        Assert.False(result, $"{value} should not be prime");
    }
}