using System.IO;
using System.Linq;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day5
{
    using IntCodeComputer;

    public class IntCodeComputerTests
    {
        [Test]
        [TestCase("101,1,2,0,99", ExpectedResult = "3,1,2,0,99")]
        [TestCase("1101,1,-2,0,99", ExpectedResult = "-1,1,-2,0,99")]
        [TestCase("1002,4,3,4,33", ExpectedResult = "1002,4,3,4,99")]
        public string Program_Execution_Should_Result(string code)
        {
            var input = Substitute.For<TextReader>();
            var output = Substitute.For<TextWriter>();
            var memory = code.Split(',').Select(int.Parse).ToArray();
            var sut = new IntCodeComputer(input, output);

            memory = sut.Process(memory);

            return string.Join(",", memory);
        }

        [Test]
        public void Program_Execution_Should_Read_Input()
        {
            var input = Substitute.For<TextReader>();
            var output = Substitute.For<TextWriter>();
            var memory = new[] {3, 1, 99};
            var sut = new IntCodeComputer(input, output);
            input.ReadLine().Returns("55");

            memory = sut.Process(memory);

            memory.Should().BeEquivalentTo(new[] {3, 55, 99});
        }

        [Test]
        public void Program_Execution_Should_Write_Memory_To_Output()
        {
            var input = Substitute.For<TextReader>();
            var output = Substitute.For<TextWriter>();
            var memory = new[] {4, 2, 99};
            var sut = new IntCodeComputer(input, output);

            memory = sut.Process(memory);

            memory.Should().BeEquivalentTo(new[] {4, 2, 99});
            output.Received(1).WriteLine(99);
        }

        [Test]
        public void Program_Execution_Should_Write_Value_To_Output()
        {
            var input = Substitute.For<TextReader>();
            var output = Substitute.For<TextWriter>();
            var memory = new[] {104, 66, 99};
            var sut = new IntCodeComputer(input, output);

            memory = sut.Process(memory);

            memory.Should().BeEquivalentTo(new[] {104, 66, 99});
            output.Received(1).WriteLine(66);
        }
        
        [Test]
        [TestCase(7, 999)]
        [TestCase(8, 1000)]
        [TestCase(9, 1001)]
        public void Program_Execution_Should_Write_Value_Depending_On_Input(int value, int expectedResult)
        {
            const string code = "3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99";

            var input = Substitute.For<TextReader>();
            var output = Substitute.For<TextWriter>();
            var memory = code.Split(',').Select(int.Parse).ToArray();
            var sut = new IntCodeComputer(input, output);

            input.ReadLine().Returns(value.ToString());

            memory = sut.Process(memory);

            output.Received(1).WriteLine(expectedResult);
        }
    }
}