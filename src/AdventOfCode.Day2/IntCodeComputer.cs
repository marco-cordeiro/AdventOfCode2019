using System;

namespace AdventOfCode.Day2
{
    public class IntCodeComputer
    {
        public int[] Process(int[] memory)
        {
            var instructionPointer = 0;

            while (true)
            {
                var opCode = memory[instructionPointer++];

                var (valid, opCodeFunc) = ValidateOpCode(opCode);
                if (!valid) break;

                var posValue1 = memory[instructionPointer++];
                var posValue2 = memory[instructionPointer++];

                var value1 = memory[posValue1];
                var value2 = memory[posValue2];
                var posResult = memory[instructionPointer++];

                memory[posResult] = opCodeFunc(value1, value2);
            }

            return memory;
        }

        private (bool, Func<int, int, int>) ValidateOpCode(int opCode)
        {
            switch (opCode)
            {
                case 1:
                    return (true, OpCode1);
                case 2:
                    return (true, OpCode2);
                case 99:
                    return (false, null);
                default:
                    throw new ArgumentOutOfRangeException($"opcode '{opCode}' is invalid");
            }
        }

        private int OpCode1(int value1, int value2)
        {
            return value1 + value2;
        }

        private int OpCode2(int value1, int value2)
        {
            return value1 * value2;
        }
    }
}
