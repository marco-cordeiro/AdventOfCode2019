using System;
using System.Linq;
using AdventOfCode.Data.Provider;

namespace AdventOfCode.Day7
{
    public class ChallengeDay7
    {
        private readonly AmplifierArrayFactory _factory;
        private readonly IDataProvider<string> _provider;

        public ChallengeDay7(AmplifierArrayFactory factory, IDataProvider<string> provider)
        {
            _factory = factory;
            _provider = provider;
        }

        public void Run()
        {
            var code = _provider.Read();

            var memorySnapshot = code.Split(',').Select(int.Parse);

            var maxOutput = 0;
            var maxOutputSequence = string.Empty;

            for (var amp1 = 0; amp1 < 5; amp1++)
            for (var amp2 = 0; amp2 < 5; amp2++)
            for (var amp3 = 0; amp3 < 5; amp3++)
            for (var amp4 = 0; amp4 < 5; amp4++)
            for (var amp5 = 0; amp5 < 5; amp5++)
            {
                var phases = new[] {amp1, amp2, amp3, amp4, amp5};
                if (phases.Length > phases.Distinct().Count())
                    continue;

                var amplifierArray = _factory.Build(memorySnapshot, phases);

                var result = amplifierArray.Amplify();

                if (result < maxOutput)
                    continue;

                maxOutput = result;
                maxOutputSequence = string.Join(",", phases);
            }
            

            Console.WriteLine($"The max output is {maxOutput} with the sequence '{maxOutputSequence}'");
        }
    }
}