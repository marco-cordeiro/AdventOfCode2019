using System.Linq;
using AdventOfCode.Day2;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day2
{
    public class IntCodeComputerTests
    {
        [Test]
        [TestCase("1,9,10,3,2,3,11,0,99,30,40,50", ExpectedResult = "3500,9,10,70,2,3,11,0,99,30,40,50")]
        [TestCase("1,0,0,0,99", ExpectedResult = "2,0,0,0,99")]
        [TestCase("2,3,0,3,99", ExpectedResult = "2,3,0,6,99")]
        [TestCase("2,4,4,5,99,0", ExpectedResult = "2,4,4,5,99,9801")]
        [TestCase("1,1,1,4,99,5,6,0,99", ExpectedResult = "30,1,1,4,2,5,6,0,99")]
        public string Program_Execution_Should_Result(string code)
        {
            var memory = code.Split(',').Select(int.Parse).ToArray();
            var sut = new IntCodeComputer();

            memory = sut.Process(memory);

            return string.Join(",", memory);
        }
    }
}