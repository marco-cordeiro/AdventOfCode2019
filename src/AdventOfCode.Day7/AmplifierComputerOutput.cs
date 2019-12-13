using System.Collections.Generic;

namespace AdventOfCode.Day7
{
    public class AmplifierComputerOutput : IAmplifierComputerOutput
    {
        private readonly Stack<int> _values;

        public AmplifierComputerOutput()
        {
            _values = new Stack<int>();
        }

        public void Write(int value)
        {
            _values.Push(value);
        }

        public int PopResult()
        {
            return _values.Pop();
        }
    }
}