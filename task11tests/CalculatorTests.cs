using Xunit;
using task11;

public class CalculatorTests
{
    [Fact]
    public void Calculator_ShouldPerformOperationsCorrectly()
    {
        dynamic calc = CalculatorFactory.CreateCalculator();

        Assert.Equal(5, calc.Add(2, 3));
        Assert.Equal(1, calc.Minus(4, 3));
        Assert.Equal(6, calc.Mul(2, 3));
        Assert.Equal(2, calc.Div(10, 5));
    }
}