using System.Collections.Generic;

namespace AdventOfCode.Day7
{
    public class AmplifierComputerInput : IAmplifierComputerInput
    {
        private readonly Stack<int> _values;

        public AmplifierComputerInput()
        {
            _values = new Stack<int>();
        }

        public int Read()
        {
            return _values.Pop();
        }

        public void PushInput(int value)
        {
            _values.Push(value);
        }
    }
}