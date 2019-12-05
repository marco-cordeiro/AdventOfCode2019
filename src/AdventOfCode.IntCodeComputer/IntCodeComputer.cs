using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode.IntCodeComputer
{
    public class IntCodeComputer
    {
        private readonly TextReader _input;
        private readonly TextWriter _output;
        private Dictionary<int, MethodInfo> _opCodes;

        public IntCodeComputer(TextReader input, TextWriter output)
        {
            _input = input;
            _output = output;

            var methods = this.GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(m => m.IsPrivate && m.Name.StartsWith("OpCode"));// && m.GetGenericArguments().Length == 0);

            _opCodes = methods.ToDictionary(m => int.Parse(m.Name.Substring(6)));
        }

        public int[] Process(int[] memory)
        {
            var instructionPointer = 0;

            while (true)
            {
                var (opCode, mode1, mode2, mode3) = ParseOpCode(memory[instructionPointer++]);

                var (valid, opCodeFunc) = ValidateOpCode(opCode);
                if (!valid) break;

                instructionPointer = (int)opCodeFunc.Invoke(this, new object[] {memory, instructionPointer, mode1, mode2, mode3});
            }

            return memory;
        }

        private (byte, byte, byte, byte) ParseOpCode(int value)
        {
            var opCode = value - ((value / 100) * 100);
            value = value / 100;
            var mode1 = value - ((value / 10) * 10);
            value = value / 10;
            var mode2 = value - ((value / 10) * 10);
            value = value / 10;
            var mode3 = value - ((value / 10) * 10);

            return ((byte) opCode, (byte) mode1, (byte) mode2, (byte) mode3);
        }

        private (bool, MethodInfo) ValidateOpCode(int opCode)
        {
            return (_opCodes.TryGetValue(opCode, out var opCodeOperation), opCodeOperation);
        }

        private int OpCode1(int[] memory, int instructionPointer, byte mode1, byte mode2, byte mode3)
        {
            var value1 = memory.Read(instructionPointer++, mode1);
            var value2 = memory.Read(instructionPointer++, mode2);
            var resultPos = memory.Read(instructionPointer++);

            memory[resultPos] = value1 + value2;

            return instructionPointer;
        }

        private int OpCode2(int[] memory, int instructionPointer, byte mode1, byte mode2, byte mode3)
        {
            var value1 = memory.Read(instructionPointer++, mode1);
            var value2 = memory.Read(instructionPointer++, mode2);
            var resultPos = memory.Read(instructionPointer++);

            memory[resultPos] = value1 * value2;

            return instructionPointer;
        }

        private int OpCode3(int[] memory, int instructionPointer, byte mode1, byte mode2, byte mode3)
        {
            var resultPos = memory.Read(instructionPointer++);

            _output.Write("Id :");
            var value = int.Parse(_input.ReadLine());

            memory[resultPos] = value;

            return instructionPointer;
        }

        private int OpCode4(int[] memory, int instructionPointer, byte mode1, byte mode2, byte mode3)
        {
            var value = memory.Read(instructionPointer++, mode1); 
            
            _output.WriteLine(value);

            return instructionPointer;
        }

        /// <summary>
        /// jump-if-true
        /// </summary>
        private int OpCode5(int[] memory, int instructionPointer, byte mode1, byte mode2, byte mode3)
        {
            var value = memory.Read(instructionPointer++, mode1);
            var jumpToPos = memory.Read(instructionPointer++, mode2);

            return value == 0 ? instructionPointer : jumpToPos;
        }

        /// <summary>
        /// jump-if-false
        /// </summary>
        private int OpCode6(int[] memory, int instructionPointer, byte mode1, byte mode2, byte mode3)
        {
            var value = memory.Read(instructionPointer++, mode1);
            var jumpToPos = memory.Read(instructionPointer++, mode2);

            return value == 0 ? jumpToPos : instructionPointer;
        }

        /// <summary>
        /// less-than
        /// </summary>
        private int OpCode7(int[] memory, int instructionPointer, byte mode1, byte mode2, byte mode3)
        {
            var value1 = memory.Read(instructionPointer++, mode1);
            var value2 = memory.Read(instructionPointer++, mode2);
            var resultPos = memory.Read(instructionPointer++);

            memory[resultPos] = value1 < value2 ? 1 : 0;

            return instructionPointer;
        }

        /// <summary>
        /// equals
        /// </summary>
        private int OpCode8(int[] memory, int instructionPointer, byte mode1, byte mode2, byte mode3)
        {
            var value1 = memory.Read(instructionPointer++, mode1);
            var value2 = memory.Read(instructionPointer++, mode2);
            var resultPos = memory.Read(instructionPointer++);

            memory[resultPos] = value1 == value2 ? 1 : 0;

            return instructionPointer;
        }


    }
}
