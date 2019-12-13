using System.Collections.Generic;

namespace AdventOfCode.Day7
{
    public interface IAmplifierComputer
    {
        int Process(int phase, int value);
        void Load(IEnumerable<int> memory);
    }
}