namespace AdventOfCode.Data.Provider
{
    public sealed class StringDataProvider : BaseDataProvider<string>
    {
        public StringDataProvider(string filename) : base(filename)
        {
        }

        protected override string ChangeType(string value)
        {
            return value;
        }
    }
}