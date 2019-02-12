using Xunit;
using calculator = AnycleLiu.Algorithm.Math.MathExpressionCalculator;

namespace AnylceLiu.Tests.Algorithm
{
    public class MathExpressionCalculatorTest
    {
        [Fact]
        public void TestInfixToSuffix()
        {
            Assert.Equal("1", string.Join(" ", calculator.InfixToSuffix("1")));
            Assert.Equal("1 2 +", string.Join(" ", calculator.InfixToSuffix("1+2")));
            Assert.Equal("1 2 3 * + 4 -", string.Join(" ", calculator.InfixToSuffix("1+2*3-4")));
            Assert.Equal("0.001 1 100 * +", string.Join(" ", calculator.InfixToSuffix("0.001+1*100")));
            Assert.Equal("0 1 -", string.Join(" ", calculator.InfixToSuffix("-1")));
            Assert.Equal("0 1 - 2 3 + 4 / 3 * +", string.Join(" ", calculator.InfixToSuffix("-1+(2+3)/4*3")));
            Assert.Equal("1 2 + 3 4 * - 5 / 6 - 1 2 3 + + +",
                string.Join(" ", calculator.InfixToSuffix("(1+2-3*4)/5-6+(1+(2+3))")));
            Assert.Equal("100 0 10 - 80 2 / - +", string.Join(" ", calculator.InfixToSuffix("100+(-10-80/2)")));
        }

        [Fact]
        public void TestCalculate()
        {
            Assert.Equal(1, calculator.Calculate("1"));
            Assert.Equal(1 + 2, calculator.Calculate("1+2"));
            Assert.Equal(1 + 2 * 3 - 4, calculator.Calculate("1+2*3-4"));
            Assert.Equal(0.001 + 1 * 100, (double)calculator.Calculate("0.001+1*100"));
            Assert.Equal(-1, calculator.Calculate("-1"));
            Assert.Equal(-1 + (2 + 3) / 4m * 3, calculator.Calculate("-1+(2+3)/4*3"));
            Assert.Equal((1 + 2 - 3 * 4) / 5m - 6 + (1 + (2 + 3)),
                calculator.Calculate("(1+2-3*4)/5-6+(1+(2+3))"));
            Assert.Equal(100 + (-10 - 80 / 2m), calculator.Calculate("100+(-10-80/2)"));
            Assert.Equal((0.3125 * 111 / 18.5) * 16 / 3, (double)calculator.Calculate("(0.3125*111/18.5)*16/3 "));
            Assert.Equal((8 + 4) * 5 - 7 / 2m + 3 - 5 * 2 * (6 / 2m) + 3 - 5 * 2 * (6 / 2m),
                calculator.Calculate("(8 + 4) * 5 - 7 / 2 +3 - 5 * 2 * (6 / 2)+ 3 - 5 * 2*(6 / 2)"));
        }
    }
}
