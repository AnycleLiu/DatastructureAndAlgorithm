using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using AnycleLiu.Algorithm;

namespace AnylceLiu.Tests.Algorithm
{
    [TestFixture]
    public class MathExpressionCalculatorTest
    {
        [Test]
        public void TestInfixToSuffix()
        {
            var calculator = new MathExpressionCalculator();
            Assert.AreEqual("1", string.Join(" ", calculator.InfixToSuffix("1")));
            Assert.AreEqual("1 2 +", string.Join(" ", calculator.InfixToSuffix("1+2")));
            Assert.AreEqual("1 2 3 * + 4 -", string.Join(" ", calculator.InfixToSuffix("1+2*3-4")));
            Assert.AreEqual("0.001 1 100 * +", string.Join(" ", calculator.InfixToSuffix("0.001+1*100")));
            Assert.AreEqual("0 1 -", string.Join(" ", calculator.InfixToSuffix("-1")));
            Assert.AreEqual("0 1 - 2 3 + 4 / 3 * +", string.Join(" ", calculator.InfixToSuffix("-1+(2+3)/4*3")));
            Assert.AreEqual("1 2 + 3 4 * - 5 / 6 - 1 2 3 + + +",
                string.Join(" ", calculator.InfixToSuffix("(1+2-3*4)/5-6+(1+(2+3))")));
            Assert.AreEqual("100 0 10 - 80 2 / - +", string.Join(" ", calculator.InfixToSuffix("100+(-10-80/2)")));
        }

        [Test]
        public void TestCalculate()
        {
            var calculator = new MathExpressionCalculator();
            Assert.AreEqual(1, calculator.Calculate("1"));
            Assert.AreEqual(1 + 2, calculator.Calculate("1+2"));
            Assert.AreEqual(1 + 2 * 3 - 4, calculator.Calculate("1+2*3-4"));
            Assert.AreEqual(0.001 + 1 * 100, calculator.Calculate("0.001+1*100"));
            Assert.AreEqual(-1, calculator.Calculate("-1"));
            Assert.AreEqual(-1 + (2 + 3) / 4m * 3, calculator.Calculate("-1+(2+3)/4*3"));
            Assert.AreEqual((1 + 2 - 3 * 4) / 5m - 6 + (1 + (2 + 3)),
                calculator.Calculate("(1+2-3*4)/5-6+(1+(2+3))"));
            Assert.AreEqual(100 + (-10 - 80 / 2m), calculator.Calculate("100+(-10-80/2)"));
            Assert.AreEqual((0.3125 * 111 / 18.5) * 16 / 3, calculator.Calculate("(0.3125*111/18.5)*16/3 "));
            Assert.AreEqual((8 + 4) * 5 - 7 / 2m + 3 - 5 * 2 * (6 / 2m) + 3 - 5 * 2 * (6 / 2m),
                calculator.Calculate("(8 + 4) * 5 - 7 / 2 +3 - 5 * 2 * (6 / 2)+ 3 - 5 * 2*(6 / 2)"));
        }
    }
}
