using System;
using System.Linq;
using AdventOfCode.Day7;
using NSubstitute;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day7
{
    public class AmplifierPart2Tests
    {
        [Test]
        [TestCase("3,26,1001,26,-4,26,3,27,1002,27,2,27,1,27,26,27,4,27,1001,28,-1,28,1005,28,6,99,0,0,5", "9,8,7,6,5", ExpectedResult = 139629729)]
        [TestCase("3,52,1001,52,-5,52,3,53,1,52,56,54,1007,54,5,55,1005,55,26,1001,54,-5,54,1105,1,12,1,53,54,53,1008,54,0,55,1001,55,1,55,2,53,55,53,4,53,1001,56,-1,56,1005,56,6,99,0,0,0,0,10", "9,7,8,5,6", ExpectedResult = 18216)]
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

            var result = sut.Amplify(true);

            return result;
        }
    }
}