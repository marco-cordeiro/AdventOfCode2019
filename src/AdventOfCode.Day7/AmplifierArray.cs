using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day7
{
    public class AmplifierArray
    {
        private readonly IAmplifier[] _amplifiers;

        public AmplifierArray(IEnumerable<IAmplifier> amplifiers)
        {
            _amplifiers = amplifiers.ToArray();
        }

        public IAmplifier this[int index] => _amplifiers[index];

        public int Amplify()
        {
            var value = 0;
            foreach (var amplifier in _amplifiers)
            {
                value = amplifier.Amplify(value);
            }

            return value;
        }
    }
}