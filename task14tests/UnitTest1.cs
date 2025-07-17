using Xunit;
using static task14.DefiniteIntegral;
using System;

namespace task14tests;

public class DefiniteIntegralTests
{
    [Fact]
    public void TestLinearFunction()
    {
        double result = Solve(-1, 1, x => x, 1e-4, 2);
        Assert.Equal(0, result, 4);
    }

    [Fact]
    public void TestSineFunction()
    {
        double result = Solve(-1, 1, Math.Sin, 1e-5, 8);
        Assert.Equal(0, result, 4);
    }

    [Fact]
    public void TestLinearFromZero()
    {
        double result = Solve(0, 5, x => x, 1e-6, 8);
        Assert.Equal(10, result, 5);
    }
}