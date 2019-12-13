using System.Collections.Generic;

namespace AdventOfCode.Day7
{
    public class Amplifier : IAmplifier
    {
        private readonly IAmplifierComputer _computer;
        private readonly IEnumerable<int> _memorySnapshot;
        private readonly int _phase;

        public Amplifier(IAmplifierComputer computer, IEnumerable<int> memorySnapshot, int phase)
        {
            _computer = computer;
            _memorySnapshot = memorySnapshot;
            _phase = phase;
        }

        public int Amplify(int value)
        {
            _computer.Load(_memorySnapshot);

            return _computer.Process(_phase, value);
        }
    }
}