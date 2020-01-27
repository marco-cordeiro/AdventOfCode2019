using System.Collections.Generic;

namespace AdventOfCode.Day7
{
    public class AmplifierComputerInput : IAmplifierComputerInput
    {
        private readonly Queue<int> _values;

        public AmplifierComputerInput()
        {
            _values = new Queue<int>();
        }

        public int Read()
        {
            return _values.Dequeue();
        }

        public void PushInput(int value)
        {
            _values.Enqueue(value);
        }
    }
}