using System.Collections.Generic;

namespace AdventOfCode.Day7
{
    public class Amplifier : IAmplifier
    {
        private readonly IAmplifierComputer _computer;
        private readonly int _phase;

        public Amplifier(IAmplifierComputer computer, IEnumerable<int> memorySnapshot, int phase)
        {
            _computer = computer;
            _computer.Load(memorySnapshot);
            _phase = phase;
        }

        public int Amplify(int value)
        {
            return _computer.Process(_phase, value);
        }
    }
}