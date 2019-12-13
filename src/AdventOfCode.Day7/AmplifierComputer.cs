using System.Collections.Generic;
using System.Linq;
using AdventOfCode.IntCode;

namespace AdventOfCode.Day7
{
    public class AmplifierComputer : IntCodeComputer, IAmplifierComputer
    {
        private readonly IAmplifierComputerInput _input;
        private readonly IAmplifierComputerOutput _output;
        private int[] _memory;

        public AmplifierComputer(IAmplifierComputerInput input, IAmplifierComputerOutput output) 
            : base(input, output)
        {
            _input = input;
            _output = output;
        }

        public int Process(int phase, int value)
        {
            _input.PushInput(value);
            _input.PushInput(phase);
            Process(_memory);
            return _output.PopResult();
        }

        public void Load(IEnumerable<int> memory)
        {
            _memory = memory.ToArray();
        }
    }
}