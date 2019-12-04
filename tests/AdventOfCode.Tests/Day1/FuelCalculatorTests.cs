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
        public int Star_Mass_Should_Be_Equal_To(int mass)
        {
            var sut = new FuelCalculator();

            return sut.Calculate(mass);
        } 
        
        [Test]
        public void Starts_Mass_Should_Be_Equal_To_Sum()
        {
            var sut = new FuelCalculator();

            var result = sut.Calculate(new [] {12, 16});

            Assert.That(result, Is.EqualTo(5));
        }
    }
}