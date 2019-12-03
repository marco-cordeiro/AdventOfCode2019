using System;
using System.IO;

namespace AdventOfCode.Day1
{
    public sealed class IntegerInputReader : IInputReader<int>, IDisposable
    {
        private readonly string _filename;
        private StreamReader _reader;


        public IntegerInputReader(string filename)
        {
            _filename = filename;
        }

        public int Read()
        {
            var reader = GetStreamReader();

            var line = reader.ReadLine();

            return int.Parse(line);
        }

        private StreamReader GetStreamReader()
        {
            if (_reader is null)
            {
                var stream = new FileStream(_filename, FileMode.Open, FileAccess.Read);
                _reader = new StreamReader(stream);
            }

            return _reader;
        }

        public bool Eof => _reader?.EndOfStream ?? false;

        public void Dispose()
        {
            _reader?.Dispose();
        }
    }
}