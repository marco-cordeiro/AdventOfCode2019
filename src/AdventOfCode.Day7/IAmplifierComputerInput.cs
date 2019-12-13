using AdventOfCode.IntCode;

namespace AdventOfCode.Day7
{
    public interface IAmplifierComputerInput : IComputerInput
    {
        void PushInput(int value);
    }
}