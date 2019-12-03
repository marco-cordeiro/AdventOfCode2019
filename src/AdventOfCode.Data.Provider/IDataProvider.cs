namespace AdventOfCode.Data.Provider
{
    public interface IDataProvider<out T>
    {
        T Read();
        bool Eof { get; }
    }
}