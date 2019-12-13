using System.IO;

namespace AdventOfCode.IntCode
{
    public class StandardComputerInput : IComputerInput
    {
        private readonly TextReader _reader;

        public StandardComputerInput(TextReader reader)
        {
            _reader = reader;
        }

        public int Read()
        {
            return int.Parse(_reader.ReadLine());
        }
    }
}