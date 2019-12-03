using System;
using System.IO;

namespace AdventOfCode.Data.Provider
{
    public abstract class BaseDataProvider<T> : IDataProvider<T>, IDisposable
    {
        private readonly string _filename;
        private StreamReader _reader;

        protected BaseDataProvider(string filename)
        {
            _filename = filename;
        }

        public T Read()
        {
            var reader = GetStreamReader();

            var line = reader.ReadLine();

            return ChangeType(line);
        }

        protected abstract T ChangeType(string value);
        
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

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _reader?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}