using System;
using System.Linq;
using AdventOfCode.Data.Provider;

namespace AdventOfCode.Day2
{
    public class ChallengeDay2Part1
    {
        private readonly IntCodeComputer _processor;
        private readonly IDataProvider<string> _dataProvider;

        public ChallengeDay2Part1(IntCodeComputer processor, IDataProvider<string> dataProvider)
        {
            _processor = processor;
            _dataProvider = dataProvider;
        }

        public void Run()
        {
            var code = _dataProvider.Read();

            var memory = code.Split(',').Select(int.Parse).ToArray();

            // restore to the "1202 program alarm" state
            memory[1] = 12;
            memory[2] = 2;
            memory = _processor.Process(memory);

            Console.WriteLine($"Program output : {memory[0]}");
        }
    }
}