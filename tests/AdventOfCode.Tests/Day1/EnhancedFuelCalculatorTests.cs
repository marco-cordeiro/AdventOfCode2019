using AdventOfCode.Day1;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day1
{
    public class EnhancedFuelCalculatorTests
    {
        [Test]
        [TestCase(14, ExpectedResult = 2)]
        [TestCase(1969, ExpectedResult = 966)]
        [TestCase(100756, ExpectedResult = 50346)]
        public int Star_Mass_Should_Be_Equal_To(int mass)
        {
            var sut = new EnhancedFuelCalculator();

            return sut.Calculate(mass);
        } 
        
        [Test]
        public void Starts_Mass_Should_Be_Equal_To_Sum()
        {
            var sut = new EnhancedFuelCalculator();

            var result = sut.Calculate(new [] {33, 45});

            Assert.That(result, Is.EqualTo(25));
        }
    }
}