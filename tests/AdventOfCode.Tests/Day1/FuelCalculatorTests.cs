using AdventOfCode.Day1;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day1
{
    public class FuelCalculatorTests
    {
        [Test]
        [TestCase(12, ExpectedResult = 2)]
        [TestCase(14, ExpectedResult = 2)]
        [TestCase(1969, ExpectedResult = 654)]
        [TestCase(100756, ExpectedResult = 33583)]
        public int Mass(int mass)
        {
            var sut = new FuelCalculator();

            return sut.Calculate(new[] {mass});
        }
    }
}