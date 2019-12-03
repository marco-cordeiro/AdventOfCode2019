namespace AdventOfCode.Day1
{
    public interface IInputReader<T>
    {
        T Read();
        bool Eof { get; }
    }
}