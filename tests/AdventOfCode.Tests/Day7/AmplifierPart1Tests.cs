using System;
using System.IO;
using System.Linq;
using AdventOfCode.Day7;
using AdventOfCode.IntCode;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day7
{
    public class AmplifierPart1Tests
    {
        [Test]
        [TestCase("3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0", "4,3,2,1,0", ExpectedResult = 43210)]
        [TestCase("3,23,3,24,1002,24,10,24,1002,23,-1,23,101,5,23,23,1,24,23,23,4,23,99,0,0", "0,1,2,3,4", ExpectedResult = 54321)]
        [TestCase("3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0", "1,0,4,3,2", ExpectedResult = 65210)]
        public int Program_Execution_Should_Result(string code, string phasesRaw)
        {
            var phases = phasesRaw.Split(',').Select(int.Parse).ToArray();
            var service = Substitute.For<IServiceProvider>();
            var factory = new AmplifierArrayFactory(new AmplifierFactory(service));
            service.GetService(typeof(IAmplifierComputer)).Returns(c =>
            {
                var input = new AmplifierComputerInput();
                var output = new AmplifierComputerOutput();

                return new AmplifierComputer(input, output);
            });
            
            var memory = code.Split(',').Select(int.Parse);
            var sut = factory.Build(memory, phases);

            var result = sut.Amplify();

            return result;
        }

        [Test]
        public void Program_Execution_Should_Read_Input()
        {
            var input = Substitute.For<IComputerInput>();
            var output = Substitute.For<IComputerOutput>();
            var memory = new[] {3, 1, 99};
            var sut = new IntCodeComputer(input, output);
            input.Read().Returns(55);

            memory = sut.Process(memory);

            memory.Should().BeEquivalentTo(new[] {3, 55, 99});
        }

        [Test]
        public void Program_Execution_Should_Write_Memory_To_Output()
        {
            var input = Substitute.For<IComputerInput>();
            var output = Substitute.For<IComputerOutput>();
            var memory = new[] {4, 2, 99};
            var sut = new IntCodeComputer(input, output);

            memory = sut.Process(memory);

            memory.Should().BeEquivalentTo(new[] {4, 2, 99});
            output.Received(1).Write(99);
        }

        [Test]
        public void Program_Execution_Should_Write_Value_To_Output()
        {
            var input = Substitute.For<IComputerInput>();
            var output = Substitute.For<IComputerOutput>();
            var memory = new[] {104, 66, 99};
            var sut = new IntCodeComputer(input, output);

            memory = sut.Process(memory);

            memory.Should().BeEquivalentTo(new[] {104, 66, 99});
            output.Received(1).Write(66);
        }
        
        [Test]
        [TestCase(7, 999)]
        [TestCase(8, 1000)]
        [TestCase(9, 1001)]
        public void Program_Execution_Should_Write_Value_Depending_On_Input(int value, int expectedResult)
        {
            const string code = "3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99";

            var input = Substitute.For<IComputerInput>();
            var output = Substitute.For<IComputerOutput>();
            var memory = code.Split(',').Select(int.Parse).ToArray();
            var sut = new IntCodeComputer(input, output);

            input.Read().Returns(value);

            memory = sut.Process(memory);

            output.Received(1).Write(expectedResult);
        }
    }
}