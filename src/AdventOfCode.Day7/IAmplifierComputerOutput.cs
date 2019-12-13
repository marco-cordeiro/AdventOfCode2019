using AdventOfCode.IntCode;

namespace AdventOfCode.Day7
{
    public interface IAmplifierComputerOutput : IComputerOutput
    {
        int PopResult();
    }
}