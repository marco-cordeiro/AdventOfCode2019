using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day7
{
    public class AmplifierArrayFactory
    {
        private readonly AmplifierFactory _factory;

        public AmplifierArrayFactory(AmplifierFactory factory)
        {
            _factory = factory;
        }

        public AmplifierArray Build(IEnumerable<int> memorySnapshot, int[] phases)
        {
            var amplifiers = phases.Select(x => _factory.Build(memorySnapshot, x));

            return new AmplifierArray(amplifiers);
        }
    }
}