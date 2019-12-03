using System;

namespace AdventOfCode.Data.Provider
{
    public sealed class PrimitiveDataProvider<T> : BaseDataProvider<T> where T : struct
    {
        public PrimitiveDataProvider(string filename) : base(filename)
        {
        }

        protected override T ChangeType(string value)
        {
            return (T) Convert.ChangeType(value, typeof(T));
        }
    }
}