using System.IO;

namespace AdventOfCode.IntCode
{
    public class StandardComputerOutput : IComputerOutput
    {
        private readonly TextWriter _writer;

        public StandardComputerOutput(TextWriter writer)
        {
            _writer = writer;
        }

        public void Write(int value)
        {
            _writer.WriteLine(value);
        }
    }
}