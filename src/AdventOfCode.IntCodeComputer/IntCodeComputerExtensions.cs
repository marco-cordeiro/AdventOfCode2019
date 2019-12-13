using System;

namespace AdventOfCode.IntCode
{
    public static class IntCodeComputerExtensions
    {
        public static int Read(this int[] memory, int instructionPointer, byte parameterMode = 1)
        {
            switch (parameterMode)
            {
                case 0:
                    var pos = memory[instructionPointer];
                    return memory[pos];
                case 1:
                    return memory[instructionPointer];
                default:
                    throw new ArgumentException(nameof(parameterMode));
            }
        }

    }
}